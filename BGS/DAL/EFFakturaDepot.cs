using System;
using Boardgamesleeves.Models;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using Boardgamesleeves.Models.ViewModels;
using System.Transactions;

namespace Boardgamesleeves.DAL
{
    public class EFFakturaDepot : IFakturaDepot
    {
        public Vare GetVare(string vareid)
        {
            return Depot.db.Vare.Find(vareid ?? "");
        }

        public bool SaveFaktura(Kurv kurv, TjekUdViewModel tjekUdViewModel)
        {
            bool res = false;

            Kunde kunde = new Kunde
            {
                Fornavn = tjekUdViewModel.Fornavn,
                Efternavn = tjekUdViewModel.Efternavn,
                Email = tjekUdViewModel.Email
            };
            
            List<Kunde> kunderFundet = Depot.db.Kunde.Where(c => c.Fornavn == kunde.Fornavn &&
                                                                 c.Efternavn == kunde.Efternavn &&
                                                                 c.Email == kunde.Email)
                                                                 .ToList() ?? new List<Kunde>();



            //Transaktion start

                TransactionOptions options = new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.Serializable,
                    //IsolationLevel = IsolationLevel.Snapshot,
                    Timeout = TransactionManager.DefaultTimeout
                };

                using (TransactionScope scope = new TransactionScope(
                       TransactionScopeOption.RequiresNew,
                       options))
                {

                    if (kunderFundet.Count > 0)
                    {
                        kunde = kunderFundet.FirstOrDefault();
                        Depot.db.Entry(kunde).State = EntityState.Modified;
                    }


                    kunde.Adresse = tjekUdViewModel.Adresse;
                    kunde.Bynavn = tjekUdViewModel.Bynavn;
                    kunde.Postnr = int.Parse(tjekUdViewModel.Postnr);
                    kunde.Land = tjekUdViewModel.Land;
                
                    Faktura faktura = new Faktura
                    {
                        Bestillingsdato = DateTime.Now,
                        Kunde = kunde
                    };

                    foreach (KurvVare vare in kurv.KurvVareList)
                    {
                        //Beregner nyt lagerantal
                        int nylagerantal = vare.Vare.LagerAntal - vare.Antal;

                        if (nylagerantal >= 0)
                        {
                            //Opdater lagerstatus
                            vare.Vare.LagerAntal = nylagerantal;

                            Bestiltvare bestiltvare = new Bestiltvare
                            {
                                Vare = null,
                                Antal = vare.Antal,
                                Vareid = vare.Vare.Vareid
                            };

                            faktura.Bestiltvare = faktura.Bestiltvare ?? new List<Bestiltvare>();
                            faktura.Bestiltvare.Add(bestiltvare);
                        }
                        else
                        {
                            //Lav rollback, da antal ikke ok.
                            break;
                           // scope.Dispose(); //opretter faktura på vare der ok og udelader de andre
                        }
                    }
              
                try
                {
                    if (faktura.Bestiltvare.Count() == kurv.KurvVareList.Count())
                    {
                        Depot.db.Faktura.Add(faktura);
                        Depot.db.SaveChanges();

                        //commit
                        scope.Complete();
                        res = true;
                    }
                    else
                    {
                        scope.Dispose();
                    }
                }
                catch {
                    //fejl under opdateirng ad db
                    scope.Dispose();
                }

            }//Transaktion slut 

            return res;

         }
    }
}
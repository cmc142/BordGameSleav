using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boardgamesleeves.DAL
{
    public static class Depot
    {
        public static readonly BGSModel db = new BGSModel();
        public static readonly int[] KoebsAntal = new int[] { 1,2,3,4,5,6,7,8,9,10 };

        //public static void SaveDB()
        //{
        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception("Ændringerne kunne ikke laves.");
        //    }
        //}
        //public BGSModel GetDB { get{ return Depot.db; } }
        //public Depot()
        //{
        //    // TODO: Complete member initialization
        //}
    }
}
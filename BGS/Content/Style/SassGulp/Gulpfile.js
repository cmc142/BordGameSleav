var gulp = require('gulp');
var sass = require('gulp-sass');

gulp.task('styles', function () {
    gulp.src('../Sass/**/*.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('../CSS/'));
});

//Watch task
gulp.task('default', function () {
    gulp.watch('../Sass/**/*.scss', ['styles']);
});
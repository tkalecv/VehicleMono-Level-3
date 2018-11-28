// gulpfile.js
var webserver = require('gulp-webserver');
var gulp = require('gulp');
var inject = require('gulp-inject');

var mainBowerFiles = require('main-bower-files');


var paths = {
    src: 'src/app',
    srcHTML: 'src/**/*.html',
    srcCSS: 'src/**/*.css',
    srcJS: 'src/**/*.js',
    index: 'src/app/index.html',
};

var inject = require('gulp-inject');

gulp.task('inject', function () {
    var css = gulp.src(paths.srcCSS);
    var js = gulp.src(paths.srcJS);
    return gulp.src(paths.index)
        .pipe(inject(css, { relative: true }))
        .pipe(inject(js, { relative: true }))
        .pipe(gulp.dest(paths.src));
});

gulp.task("inject-bower-files", function () {
    return gulp.src(paths.index)
        .pipe(inject(gulp.src(mainBowerFiles(), { read: false }), { starttag: '<!-- inject:bower -->' }))
        .pipe(gulp.dest(paths.src));
});

gulp.task('serve', function () {
    return gulp.src(paths.src)
        .pipe(webserver({
            port: 4000,
            livereload: true
        }));
});



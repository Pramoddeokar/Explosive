
(function (app) {
    'use strict';

    app.controller('ProductCtrl', ProductCtrl);

    ProductCtrl.$inject = ['$scope', '$location', '$routeParams', 'apiService', 'notificationService'];

    function ProductCtrl($scope, $location, $routeParams, apiService, notificationService) {
        $scope.pageClass = 'page-movies';
        $scope.products = {};
        $scope.loadingproducts = true;
        $scope.isReadOnly = false;

        function loadProducts() {

            $scope.loadingproducts = true;

            apiService.get('/api/products/details/' + $routeParams.id, null,
            ProductLoadCompleted,
            ProductLoadFailed);
        }

        function ProductLoadCompleted(result) {
            $scope.products = result.data;
            $scope.loadingMovie = false;

        }

        function ProductLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        $scope.movie = {};
        $scope.genres = [];
        $scope.loadingMovie = true;
        $scope.isReadOnly = false;
        $scope.UpdateMovie = UpdateMovie;
        $scope.prepareFiles = prepareFiles;
        $scope.openDatePicker = openDatePicker;

        $scope.dateOptions = {
            formatYear: 'yy',
            startingDay: 1
        };
        $scope.datepicker = {};

        var movieImage = null;

        function loadMovie() {

            $scope.loadingMovie = true;

            apiService.get('/api/movies/details/' + $routeParams.id, null,
            movieLoadCompleted,
            movieLoadFailed);
        }

        function movieLoadCompleted(result) {
            $scope.movie = result.data;
            $scope.loadingMovie = false;

            loadGenres();
        }

        function movieLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function genresLoadCompleted(response) {
            $scope.genres = response.data;
        }

        function genresLoadFailed(response) {
            notificationService.displayError(response.data);
        }

        function loadGenres() {
            apiService.get('/api/genres/', null,
            genresLoadCompleted,
            genresLoadFailed);
        }

        function UpdateMovie() {
            if (movieImage) {
                fileUploadService.uploadImage(movieImage, $scope.movie.ID, UpdateMovieModel);
            }
            else
                UpdateMovieModel();
        }

        function UpdateMovieModel() {
            apiService.post('/api/movies/update', $scope.movie,
            updateMovieSucceded,
            updateMovieFailed);
        }

        function prepareFiles($files) {
            movieImage = $files;
        }

        function updateMovieSucceded(response) {
            console.log(response);
            notificationService.displaySuccess($scope.movie.Title + ' has been updated');
            $scope.movie = response.data;
            movieImage = null;
        }

        function updateMovieFailed(response) {
            notificationService.displayError(response);
        }

        function openDatePicker($event) {
            $event.preventDefault();
            $event.stopPropagation();

            $scope.datepicker.opened = true;
        };

        loadMovie();
    }

})(angular.module('ngEdu'));
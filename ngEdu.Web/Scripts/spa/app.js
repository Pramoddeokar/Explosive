(function () {
    'use strict';

    angular.module('ngEdu', ['common.core', 'common.ui'])
        .config(config)
        .run(run);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {

        $stateProvider
            .state('index', {
                url: "/",
                templateUrl: '/scripts/spa/home/index.html',
                controller: 'indexCtrl',
            })
            .state('login', {
                url: "/login",
                templateUrl: "/scripts/spa/account/login.html",
                controller: 'loginCtrl'
            })

            .state('Products', {
                url: "/Products",
                templateUrl: "/scripts/spa/products/Products.html",
                controller: 'ProductCtrl'
            })
            .state('register', {
                url: "/register",
                templateUrl: "/scripts/spa/account/register.html",
                controller: "registerCtrl"
            })
            .state('customers', {
                url: "/customers",
                templateUrl: "/scripts/spa/customers/customers.html",
                controller: "customersCtrl"
            })
            .state('customers-register', {
                url: "/customers/register",
                templateUrl: "/scripts/spa/customers/register.html",
                controller: "customersRegCtrl"
            })
             .state('movies', {
                 url: "/movies",
                 templateUrl: "/scripts/spa/movies/movies.html",
                 controller: "moviesCtrl"
             })
             .state('movies-add', {
                 url: "/movies/add",
                 templateUrl: "/scripts/spa/movies/add.html",
                 controller: "movieAddCtrl"
             })
            .state('movies-details', {
                url: "/movies/:id",
                templateUrl: "/scripts/spa/movies/details.html",
                controller: "movieDetailsCtrl"
            })
            .state('movies-edit', {
                url: "/movies/edit/:id",
                templateUrl: "/scripts/spa/movies/edit.html",
                controller: "movieEditCtrl"
            })
            .state('rental', {
                url: "rental",
                templateUrl: "/scripts/spa/rental/rental.html",
                controller: "rentStatsCtrl"
            });
        $urlRouterProvider.otherwise("/");

    }

    run.$inject = ['$rootScope', '$location', '$cookieStore', '$http'];

    function run($rootScope, $location, $cookieStore, $http) {
        // handle page refreshes
        $rootScope.repository = $cookieStore.get('repository') || {};
        if ($rootScope.repository.loggedUser) {
            $http.defaults.headers.common['Authorization'] = $rootScope.repository.loggedUser.authdata;
        }

        $(document).ready(function () {
            $(".fancybox").fancybox({
                openEffect: 'none',
                closeEffect: 'none'
            });

            $('.fancybox-media').fancybox({
                openEffect: 'none',
                closeEffect: 'none',
                helpers: {
                    media: {}
                }
            });

            $('[data-toggle=offcanvas]').click(function () {
                $('.row-offcanvas').toggleClass('active');
            });
        });
    }

    isAuthenticated.$inject = ['membershipService', '$rootScope', '$location'];

    function isAuthenticated(membershipService, $rootScope, $location) {
        if (!membershipService.isUserLoggedIn()) {
            $rootScope.previousState = $location.path();
            $location.path('/login');
        }
    }

})();
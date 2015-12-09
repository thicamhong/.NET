///<reference path="angular.js"/>

(function () {
    // On ajoute la dependance phonecatFilters au module PhonecatApp
    var app = angular.module('PhonecatApp',
                        ['phonecatFilters', 'phonecatAnimations',
                        'ngRoute', 'PhonecatControllers',
                        'PhonecatServices', 'PhonecatDirectives']);

    // Le code suivant est la table de mapping de routage
    app.config(['$routeProvider',
       function ($routeProvider) {
           $routeProvider.
           when('/phones', {
               templateUrl: 'views/phones.html',
           }).
           when('/phone/:phoneId', {
               templateUrl: 'views/phone.html',
           }).
           when('/phoneform/:phoneId', {
               templateUrl: 'views/phoneform.html',
           }).
           when('/about', {
                   templateUrl: 'views/about.html'
           }).
           otherwise({
               redirectTo: '/phones'
           });
       }]);
    

   
})();


///<reference path="angular.js"/>


(function () {
    var phonecatDirectives = angular.module('PhonecatDirectives', []);


    phonecatDirectives.directive('phoneItem', function () {
        return {
            restrict: 'E',
            templateUrl: 'views/phone-item.html'
        };
    });

    
    phonecatDirectives.directive('basketItem', function () {
        return {
            restrict: 'E',
            templateUrl: 'views/basket-item.html'
        };
    });
    
    phonecatDirectives.directive('elementBasket', function () {
        return {
            restrict: 'A',
            templateUrl: 'views/element-basket.html'
        };
    });

})();




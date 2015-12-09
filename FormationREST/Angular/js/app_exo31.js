///<reference path="angular.js"/>

(function () {
    var app = angular.module('PhonecatApp', []);

 
    // On definit un controller appelé : PhoneController
    app.controller('PhoneController', 
                    function () {
                        this.product = nexus;
                    }
                  );

})();


var nexus = {
    "id": "nexus-s",
    "name": "Nexus S",
    "snippet": "Fast just got faster with Nexus S. A pure Google experience, Nexus S is the first phone to run Gingerbread (Android 2.3), the fastest version of Android yet.",
    canPurchase: true
}



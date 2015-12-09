var phonecatServices = angular.module('PhonecatServices', ['ngResource']);

phonecatServices.factory('Counter', function() {
	var s = {};              
	var i = 0;
             
	s.count = function() {
		i++;
	};
	
	s.getCount = function() {
		return i;
	}
                    
    return s;
});

phonecatServices.value('User', {
	user: {
		firstname: 'Cyril',
		lastname: 'Vincent',
    },
	role: 'admin'
});

var basket = function() {
	this.phones = [];
	
	this.add = function(p) {
		this.phones.push(p);
	}
	
	this.count = function() {
		return this.phones.length;
	}
}


// Creation du service factory Phone
phonecatServices.factory('Phone', ['$resource',
    function ($resource) {
        return $resource('http://localhost:61737/api/phones/:phoneId', {}, {
            query:{method:'GET', params:{phoneId:'all'}, isArray:true}
        });
    
    }]);


// Creation du service de Service Basket
phonecatServices.service('Basket', [basket]);


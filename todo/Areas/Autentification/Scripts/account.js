/* globals angular */
(function () {
	'use strict';

	var app = angular.module('accountApp', ['ngResource', 'ngRoute']);

	app.factory('AccountResource', ['$resource', '$routeParams', '$location', function ($resource, $routeParams, $location) {
		var resource = $resource('/Autentification/Account/Login', {}, {
			login: {
				method: "POST"
				, params: {
					ReturnUrl: $location.protocol() + '://' + $location.host() +
						(':' + $location.port() || '') + ($routeParams.ReturnUrl || '')
				}
			}
		});
		return resource;
	}]);

	app.controller('AccountController', ['AccountResource', '$window',
		function (AccountResource, $window) {
			this.user = {
				username: '',
				password: ''
			};
			this.login = function (user) {
				AccountResource.login(user, function (result) {
					$window.location.href = result.ReturnUrl;
				});
			};
		}]
	);

})();
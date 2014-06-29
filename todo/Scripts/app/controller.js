var phonecatApp = angular.module('todoApp', ['ngResource']);

phonecatApp.factory('Todo', function ($resource) {
	var resource = $resource('api/todoes',{},{
		get:{
			method:"GET",
			isArray:true
		},
	});
	return resource;
});

phonecatApp.controller('TodoCtrl', function ($scope, Todo) {
	$scope.todoes = Todo.get();
});
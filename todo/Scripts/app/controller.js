var phonecatApp = angular.module('todoApp', ['ngResource']);

phonecatApp.factory('Todo', function ($resource) {
	var resource = $resource('api/todoes',{},{
		get:{
			method:"GET",
			isArray:true
		},
		push: {
			method: "POST"
		},
		put: {
			method: "PUT"
		}
	});
	return resource;
});

phonecatApp.controller('TodoCtrl', function ($scope, Todo) {
	$scope.todoes = Todo.get();
	$scope.add = function (todo) {
		Todo.push(todo, function (r) {
			$scope.todoes.push(r);
		});
	}
	$scope.update = function (todo) {
		Todo.put(todo);
	}
});
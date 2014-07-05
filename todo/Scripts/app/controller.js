(function(){
	var app = angular.module('todoApp', ['ngResource']);

	app.factory('TodoResource', ['$resource', function ($resource) {
		var resource = $resource('api/todoes', {}, {
			get: {
				method: "GET",
				isArray: true
			},
			push: {
				method: "POST"
			},
			put: {
				method: "PUT"
			}
		});
		return resource;
	}]);
	
	app.directive('todoList',['TodoResource', function (TodoResource) {
		return	 {
			restrict: 'E',
			templateUrl: '/content/app/todo-list.html',
			controller: ['TodoResource', function (TodoResource) {
				this.todo = {};
				this.todoes = [];
				var ctrl = this;
				TodoResource.get(function(data){
					ctrl.todoes = data;
				});

				this.add = function (todo) {
					TodoResource.push(todo, function (r) {
						ctrl.todoes.push(r);
					});
				};

				this.update = function (todo) {
					TodoResource.put(todo);
				};
			}],
			controllerAs: 'TodoListCtrl'
		}
	}]);
})();
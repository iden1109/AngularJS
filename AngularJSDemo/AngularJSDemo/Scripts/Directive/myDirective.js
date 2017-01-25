angular.module("myDirective.main", []).directive("myDirective", ["$filter", "$http", function($filter, $http){
    return {
        restrict: "A",
        templateUrl: "/myDirective/demo.html",
        scope: {
            data:"="
        },
        link: function (scope, element, attrs) {
            scope.name = scope.data;
        }
    }
}]).run(["$templateCache", function($templateCache) {
    var view = function(){
        return {
            /*
            <div>Hello {{name}}</div>
            */
        }
    }
    var lines = new String(view);
    lines = lines.substring(lines.indexOf("/*") + 3, lines.lastIndexOf("*/"));
    $templateCache.put("/myDirective/demo.html", lines);
}])

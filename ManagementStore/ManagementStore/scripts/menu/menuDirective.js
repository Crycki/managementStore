'use strict';

angular.module('ManagmentStore').directive("highlightActive", [function () {
    return {
        restrict: "A",
        controller: ["$scope", "$element", "$location", function ($scope, $element, $location) {
            var links = $element.find("a");
            var path = function() {
                return $location.path();
            };

            var highlightActive = function(links, path) {
                path = path.replace(/[0-9]/g, '');
                path = path.replace('//', '/');
                angular.forEach(links, function(link) {
                    var $link = angular.element(link);
                    var $li = $link.parent("li");
                    var href = $link.attr("href");
                    href = href.replace('.','');
                    if ($li.hasClass("selected")) {
                        $li.removeClass("selected");
                    }
                    if (0 === path.indexOf(href)) {
                        $li.addClass("selected");
                    }
                });
            };

            $scope.$watch(path, function (newVal, oldVal) {
                if (newVal !== oldVal) {
                    highlightActive(links, $location.path());
                }
            });
            highlightActive(links, $location.path());
        }]
    }
}])
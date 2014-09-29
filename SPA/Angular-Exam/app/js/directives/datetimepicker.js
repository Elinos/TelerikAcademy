app.directive('datetimepicker', function() {
    return {
        restrict: 'A',
        require : 'ngModel',
        link : function (scope, element) {
            $(function(){
                element.datetimepicker()
            });
        }
    }
});

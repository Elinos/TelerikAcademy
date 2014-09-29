app.factory('myErrorHandler', function ($q, notifier) {
    return {
        'response': function (response) {
            return response || $q.when(response);
        },
        'responseError': function (rejection) {
            if (rejection.status === 0) {
                notifier.error("Server is down!");
            } else if (rejection.status === 500) {
                notifier.error('Server error!');
            }
            else if (rejection.status === 401) {
                notifier.error('Unauthorized!');
            }
            else {
                if (rejection.data.message) {
                    notifier.error(rejection.data['message']);
                }
                else {
                    notifier.error(rejection.data['error_description']);
                }

            }
            return $q.reject(rejection);
        }
    };
});
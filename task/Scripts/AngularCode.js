var app = angular.module("myApp", []);
app.controller("myCtrl", function ($scope, $http) {
    debugger;
    $scope.InsertData = function () {
        var Action = document.getElementById("btnSave").getAttribute("value");
        if (Action == "Submit") {
            $scope.task = {};
            $scope.task.name = $scope.name;
            $scope.task.description = $scope.description;
            $scope.task.dateCreated = $scope.dateCreated;
            $scope.task.dateUpdated = $scope.dateUpdated;
            $http({
                method: "post",
                url: "/Task/Insert_task",
                datatype: "json",
                data: JSON.stringify($scope.task)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.name = "";
                $scope.description= "";
                $scope.dateCreated= "";
                $scope.dateUpdated = "";
            })
        } else {
            $scope.task = {};
            $scope.task.id = $scope.id;
            $scope.task.name = $scope.name;
            $scope.task.description = $scope.description;
            $scope.task.dateCreated = $scope.dateCreated;
            $scope.task.dateUpdated = $scope.dateUpdated;
            $scope.task.id = document.getElementById("Id").value;
            $http({
                method: "post",
                url: "/Task/Update_task",
                datatype: "json",
                data: JSON.stringify($scope.task)
            }).then(function (response) {
                alert(response.data);
                $scope.GetAllData();
                $scope.name = "";
                $scope.description = "";
                $scope.dateCreated = "";
                $scope.dateUpdated = "";
                document.getElementById("btnSave").setAttribute("value", "Submit");
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Task";
            })
        }
    }
    $scope.GetAllData = function () {
        $http({
            method: "get",
            url: "/Task/Get_AllTask"
        }).then(function (response) {
            $scope.tasks = response.data;
        }, function () {
            alert("Error Occur");
        })
    };
    $scope.Deletetask = function (tk) {
        $http({
            method: "post",
            url: "/Task/Delete_task",
            datatype: "json",
            data: JSON.stringify(tk)
        }).then(function (response) {
            alert(response.data);
            $scope.GetAllData();
        })
    };
    $scope.Updatetask = function (tk) {
        document.getElementById("Id").value = tk.id;
        $scope.name = tk.name;
        $scope.description = tk.description;
        $scope.dateCreated = tk.dateCreated;
        $scope.dateCreated = tk.dateUpdated;
        document.getElementById("btnSave").setAttribute("value", "Update");
        document.getElementById("btnSave").style.backgroundColor = "Yellow";
        document.getElementById("spn").innerHTML = "Update Task Information";
    }
})
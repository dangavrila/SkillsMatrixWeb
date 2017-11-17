(function startup() {
    var $sidebarAndWrapper = $("#sidebar,#wrapper"); //jQuerry elements wrap
    var $icon = $("#sidebarToggle i.fa");
    var me = this;
    me.projectViewModel = new ProjectViewModel();

    ko.applyBindings(me.projectViewModel);

    $("#sidebarToggle").on("click", function () {
        $sidebarAndWrapper.toggleClass("hide-sidebar");
        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $icon.removeClass("fa-angle-left");
            $icon.addClass("fa-angle-right");
        } else {
            $icon.addClass("fa-angle-left");
            $icon.removeClass("fa-angle-right");
        }
    });

    $("#selectProject").on("change", function () {
        me.request(this.value);
    });

    function displaySeats(seats) {
        $("#selectSeat").empty();
        $("#selectSeat").append("<option value='0'>Please select project</option>");

        seats.forEach(function (element) {
            var optionTag = "<option value='{id}'>{positionName}</option>";
            optionTag = optionTag.replace("{id}", element.id).replace("{positionName}", element.positionName);
            $("#selectSeat").append(optionTag);
        });
    };

    $("#selectSeat").on("change", function () {
        me.showTechnologiesPerSeat(this.value);
    });

    me.request = function makeRequest(projectId) {
        var urlAPI = "/api/projects/" + projectId;

        $.ajax({
            method: "GET",
            url: urlAPI,
            dataType: "json"
        })
            .done(function (data, status, jqXHR) {
                if (data !== undefined && jqXHR.status === 200) {
                    me.projectViewModel.name(data.name);
                    me.projectViewModel.hours(data.hoursNeed);
                    me.projectViewModel.isOpen(data.isOpen);
                    me.projectViewModel.deadlineDate(data.deadline);
                    me.projectViewModel.location(data.location);
                    me.projectViewModel.minSkillLevel(data.minimumSkillLevel);

                    displaySeats(data.seats);
                }
                else {
                    me.projectViewModel.name("");
                    me.projectViewModel.hours("");
                    me.projectViewModel.isOpen("");
                    me.projectViewModel.deadlineDate("");
                    me.projectViewModel.location("");
                    me.projectViewModel.minSkillLevel("");
                }
            });
    };

    me.showTechnologiesPerSeat = function createRequest(seatId) {
        var urlAPI = "/api/seats?seatId=" + seatId;

        $.ajax({
            method: "GET",
            url: urlAPI,
            dataType: "json"
        })
            .done(function (data, status, jqXHR) {
                if (data !== undefined && jqXHR.status === 200) {
                    me.projectViewModel.technologies(data);
                }
                else {
                    me.projectViewModel.technologies([]);
                }
            });
    };
})();

function ProjectModel(name, hours, isOpen, deadlineDate, location, minSkillLevel) {
    this.name = ko.observable(name);
    this.hours = ko.observable(hours);
    this.isOpen = ko.observable(isOpen);
    this.deadlineDate = ko.observable(deadlineDate);
    this.location = ko.observable(location);
    this.minSkillLevel = ko.observable(minSkillLevel);
};

function ProjectViewModel() {
    var self = this;
    self.name = ko.observable("");
    self.hours = ko.observable("");
    self.isOpen = ko.observable("");
    self.deadlineDate = ko.observable("");
    self.location = ko.observable("");
    self.minSkillLevel = ko.observable("");

    self.technologies = ko.observableArray([]);
};





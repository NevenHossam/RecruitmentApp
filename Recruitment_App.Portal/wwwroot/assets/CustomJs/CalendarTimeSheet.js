

!function ($) {
    "use strict";
    var CalendarApp = function () {
        this.$body = $("body")
        this.$calendar = $('#calendar'),
            this.$event = ('#calendar-events div.calendar-events'),
            this.$categoryForm = $('#add-new-event form'),
            this.$extEvents = $('#calendar-events'),
            this.$modal = $('#my-event'),
            this.$saveCategoryBtn = $('.save-category'),
            this.$calendarObj = null
    };
    /* on click on event */
    //CalendarApp.prototype.onEventClick = function (calEvent, jsEvent, view) {

    //    var from = $("#fromResVal").val();
    //    var to = $("#toResVal").val();
    //    var coachName = $("#coachName").val();
    //    var courtName = $("#courtName").val();
    //    var EventName = $("#EventName").val();
    //    var EventDetails = $("#EventDetails").val();
    //    var $this = this;
    //    var form = $("<form ></form>");
    //    form.append("<label>" + EventName + "</label>");
    //    form.append("<div class='input-group'><input class='form-control' disabled type=text value='" +
    //        calEvent.title +
    //        "' /></div>");

    //    form.append("<label>" + courtName + " </label>");
    //    form.append("<div class='input-group'><input class='form-control' disabled type=text value='" +
    //        calEvent.CourtName +
    //        "' /></div>");

    //    form.append("<label>" + coachName + "</label>");
    //    form.append("<div class='input-group'><input class='form-control' disabled type=text value='" +
    //        calEvent.CouchName +
    //        "' /></div>");

    //    form.append("<label> " + from + "</label>");
    //    form.append("<div class='input-group'><input class='form-control' disabled type=text value='" + calEvent.FromHour + "' /></div>");

    //    form.append("<label> " + to + "</label>");
    //    form.append("<div class='input-group'><input class='form-control' disabled type=text value='" + calEvent.ToHour + "' /></div>");

    //    $this.$modal.modal({
    //        backdrop: 'static'
    //    });
    //    $this.$modal.find('.delete-event').show().end().find('.save-event').hide().end().find('.modal-body').empty()
    //        .prepend(form).end().find('.delete-event').unbind('click').click(function () {
    //            $this.$calendarObj.fullCalendar('removeEvents',
    //                function (ev) {
    //                    return (ev._id == calEvent._id);
    //                });
    //            $this.$modal.modal('hide');
    //        });
    //    $this.$modal.find('form').on('submit',
    //        function () {
    //            calEvent.title = form.find("input[type=text]").val();
    //            $this.$calendarObj.fullCalendar('updateEvent', calEvent);
    //            $this.$modal.modal('hide');
    //            return false;
    //        });
    //},
        /* Initializing */
        CalendarApp.prototype.init = function () {

            var calenderLang = 'es';
          
           
            var $this = this;
            $this.$calendarObj = $this.$calendar.fullCalendar({
                defaultView: 'month',
                handleWindowResize: true,
              /*  defaultDate: selectedDate,*/
                header: {
                    left: null,
                    center: 'title',
                    right: null
                },
                locale: calenderLang,
                events: null,
                editable: false,
                droppable: false,
                eventLimit: false,
                selectable: false,
                drop: null,
                select: null,
                eventClick: function (calEvent, jsEvent, view) { $this.onEventClick(calEvent, jsEvent, view); }

            });
        },
        //init CalendarApp
        $.CalendarApp = new CalendarApp, $.CalendarApp.Constructor = CalendarApp;

}(window.jQuery),


    function ($) {
       
    $.CalendarApp.init();
        //var GroupId = $("#GroupId").val();

        //"use strict";
        //$.ajax({
        //    "url": '/Member/Calendar/ShowSchedule',
        //    type: "POST",
        //    "data": { startFromDate: selectedDate, groupId: GroupId },
        //    success: function (data) {
        //        $.CalendarApp.init(data);
        //    }
        //});
    }(window.jQuery);




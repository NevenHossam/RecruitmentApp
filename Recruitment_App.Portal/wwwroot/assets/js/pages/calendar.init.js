!(function (l) {
    "use strict";

    function e() {
        (this.$body = l("body")),
            (this.$modal = l("#event-modal")),
            (this.$calendar = l("#calendar")),
            (this.$formEvent = l("#form-event")),
            (this.$btnNewEvent = l("#btn-new-event")),
            (this.$btnDeleteEvent = l("#btn-delete-event")),
            (this.$btnSaveEvent = l("#btn-save-event")),
            (this.$modalTitle = l("#modal-title")),
            (this.$calendarObj = null),
            (this.$selectedEvent = null),
            (this.$newEventData = null);
    }
        (e.prototype.onEventClick = function (e) {
        debugger;
        this.$formEvent[0].reset(),
            this.$formEvent.removeClass("was-validated"),
            (this.$newEventData = null),
            this.$btnDeleteEvent.show(),
            this.$modalTitle.text("Edit Event"),
            this.$modal.show(),
            (this.$selectedEvent = e.event),
            l("#Working-Hours").val(this.$selectedEvent.title),
            l("#btn-save-event").hide(),
            l("#Work-Times").val(this.$selectedEvent.classNames[0] == "bg-dark" ? "True" : "False");

    }),
        (e.prototype.onSelect = function (e) {
            this.$formEvent[0].reset(),
                this.$formEvent.removeClass("was-validated"),
                (this.$selectedEvent = null),
                (this.$newEventData = e),
                this.$btnDeleteEvent.hide(),
                this.$modalTitle.text("Add Working Hours"),
                this.$modal.show(),
                this.$calendarObj.unselect();
        }),
        (e.prototype.init = function (data) {
            this.$modal = new bootstrap.Modal(document.getElementById("event-modal"), {
                keyboard: !1,
            });
            var e = new Date(l.now());

            var t = data,
                a = this;
            (a.$calendarObj = new FullCalendar.Calendar(a.$calendar[0], {
                slotDuration: "00:15:00",
                slotMinTime: "08:00:00",
                slotMaxTime: "19:00:00",
                themeSystem: "bootstrap",
                timeZone: 'UTC',
                bootstrapFontAwesome: !1,
                buttonText: {
                    today: "Today",
                    month: "Month",
                    week: "Week",
                    day: null,
                    list: "List",
                    prev: "Prev",
                    next: "Next",
                },
                initialView: "dayGridMonth",
                handleWindowResize: !0,
                height: l(window).height() - 200,
                headerToolbar: {
                    left: "prev,next,today",
                    center: "title",
                    //right: "dayGridMonth,timeGridWeek,timeGridDay,listMonth"
                    right: "dayGridMonth",
                },

                initialEvents: t,
                editable: !0,
                droppable: !0,
                selectable: !0,
                dateClick: function (e) {
                    a.onSelect(e);
                },
                eventClick: function (e) {
                    a.onEventClick(e);
                },
            })),
                a.$calendarObj.render(),
                a.$btnNewEvent.on("click", function (e) {
                    a.onSelect({
                        date: new Date(),
                        allDay: !0,
                    });
                }),
                a.$formEvent.on("submit", function (e) {
                    debugger;
       
                    console.log(a.$selectedEvent);

                    var day = a.$newEventData.date;
                    var workingHours = l("#Working-Hours").val();
                    var nightShift = l("#Work-Times").val();
                    var id = $("#EmpId").val();

                    e.preventDefault();
                    var t, n = a.$formEvent[0];

                    "use strict";
                    $.ajax({
                        "url": '/TimeSheet/AddTimeSheet',
                        type: "POST",
                        "data": { id: id, day: day, workingHours: workingHours, nightShift: nightShift  },
                        success: function (data) {
                            console.log(data);
                            if (data != "") {
                                Notiflix.Notify.Failure(data);
                            } else {
                                Notiflix.Notify.Success("Your Data has been saved successfully");

                                n.checkValidity()
                                    ? (a.$selectedEvent
                                        ? (a.$selectedEvent.setProp("title", workingHours), a.$selectedEvent.setProp("classNames", [nightShift == "True" ? "bg-dark" : "bg-success"]))
                                        : ((t = {
                                            title: workingHours,
                                            start: a.$newEventData.date,
                                            allDay: a.$newEventData.allDay,
                                            className: nightShift == "True" ? "bg-dark" : "bg-success",
                                        }),
                                            a.$calendarObj.addEvent(t)),
                                        a.$modal.hide())
                                    : (e.stopPropagation(), n.classList.add("was-validated"));
                            }

                        }
                    });

                }


                ),
                l(
                    a.$btnDeleteEvent.on("click", function (e) {
                        var date = a.$selectedEvent._instance.range.start;
                        var id = $("#EmpId").val();
                        "use strict";
                        $.ajax({
                            "url": '/TimeSheet/DeleyeTimeSheet',
                            type: "POST",
                            "data": { id: id, date: date },
                            success: function (data) {
                                Notiflix.Notify.Success(data);

                                a.$selectedEvent && (a.$selectedEvent.remove(), (a.$selectedEvent = null), a.$modal.hide());

                            }
                        });
                       
                    })
                );
        }),
        (l.CalendarApp = new e()),
        (l.CalendarApp.Constructor = e);
})(window.jQuery),
    (function () {
        "use strict";
        var id = $("#EmpId").val();
        var events = [];
        "use strict";
        $.ajax({
            "url": '/Employee/ShowSchedule',
            type: "POST",
            "data": { id: id },
            success: function (data) {
                window.jQuery.CalendarApp.init(data);
            }
        });

    })();

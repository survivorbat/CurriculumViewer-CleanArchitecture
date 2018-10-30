import "materialize-css";
import { isNullOrUndefined } from "util";

document.addEventListener('DOMContentLoaded', function () {
	var elems = document.querySelectorAll('.collapsible');
	var instances = M.Collapsible.init(elems);
});

document.addEventListener('DOMContentLoaded', function () {
    var options = {
		format: 'dd-mm-yyyy',
        selectYears: true,
        i18n: {
            cancel: "Annuleer",
            months: [
                "januari",
                "februar",
                "maart",
                "april",
                "mei",
                "juni",
                "juli",
                "augustus",
                "september",
                "oktober",
                "november",
                "december"
            ],
            monthsShort: [
                "jan",
                "feb",
                "mrt",
                "apr",
                "mei",
                "jun",
                "jul",
                "aug",
                "sep",
                "okt",
                "nov",
                "dec"
            ],
            weekdays: [
                "Zondag",
                "Maandag",
                "Dinsdag",
                "Woensdag",
                "Donderdag",
                "Vrijdag",
                "Zaterdag"
            ],
            weekdaysShort: [
                "Zondag",
                "Maandag",
                "Dinsdag",
                "Woensdag",
                "Donderdag",
                "Vrijdag",
                "Zaterdag"
            ],
            weekdaysAbbrev: [
                "Z",
                "M",
                "D",
                "W",
                "D",
                "V",
                "Z"
            ]
        }
    };

    var elems = document.querySelectorAll('.datepicker.datepicker-examprogram');
    var instances = M.Datepicker.init(elems, options);
});

document.addEventListener('DOMContentLoaded', function () {
    var options = {
        format: "dd-mm-yyyy",
        i18n: {
            cancel: "Annuleer",
            months: [
                "januari",
                "februar",
                "maart",
                "april",
                "mei",
                "juni",
                "juli",
                "augustus",
                "september",
                "oktober",
                "november",
                "december"
            ],
            monthsShort: [
                "jan",
                "feb",
                "mrt",
                "apr",
                "mei",
                "jun",
                "jul",
                "aug",
                "sep",
                "okt",
                "nov",
                "dec"
            ],
            weekdays: [
                "Zondag",
                "Maandag",
                "Dinsdag",
                "Woensdag",
                "Donderdag",
                "Vrijdag",
                "Zaterdag"
            ],
            weekdaysShort: [
                "Zondag",
                "Maandag",
                "Dinsdag",
                "Woensdag",
                "Donderdag",
                "Vrijdag",
                "Zaterdag"
            ],
            weekdaysAbbrev: [
                "Z",
                "M",
                "D",
                "W",
                "D",
                "V",
                "Z"
            ]
        }
    };

    var elems = document.querySelectorAll('.datepicker.datepicker-examprogram');
    var instances = M.Datepicker.init(elems, options);
});

document.addEventListener('DOMContentLoaded', function () {
    var options = {
        format: "dd-mm-yyyy",
        i18n: {
            cancel: "Annuleer",
            months: [
                "januari",
                "februar",
                "maart",
                "april",
                "mei",
                "juni",
                "juli",
                "augustus",
                "september",
                "oktober",
                "november",
                "december"
            ],
            monthsShort: [
                "jan",
                "feb",
                "mrt",
                "apr",
                "mei",
                "jun",
                "jul",
                "aug",
                "sep",
                "okt",
                "nov",
                "dec"
            ],
            weekdays: [
                "Zondag",
                "Maandag",
                "Dinsdag",
                "Woensdag",
                "Donderdag",
                "Vrijdag",
                "Zaterdag"
            ],
            weekdaysShort: [
                "Zondag",
                "Maandag",
                "Dinsdag",
                "Woensdag",
                "Donderdag",
                "Vrijdag",
                "Zaterdag"
            ],
            weekdaysAbbrev: [
                "Z",
                "M",
                "D",
                "W",
                "D",
                "V",
                "Z"
            ]
        }
    };

    var elems = document.querySelectorAll('.datepicker.datepicker-exam');
    var instances = M.Datepicker.init(elems, options);
});

document.addEventListener('DOMContentLoaded', function () {
    var options = {
        twelveHour: false,
        i18n: {
            cancel: "Annuleer"
        }
    };

    var elems = document.querySelectorAll('.timepicker');
    var instances = M.Timepicker.init(elems, options);

    var element = document.querySelectorAll('.btn-flat.timepicker-close.waves-effect')[1];

    if (!isNullOrUndefined(element)) {
        element.classList.add("timepicker-done");
        document.querySelectorAll('.btn-flat.timepicker-close.waves-effect.timepicker-done')[0].classList.remove("timepicker-close");
        document.querySelectorAll('.btn-flat.timepicker-done.waves-effect')[0].textContent = "OK";
    }
});
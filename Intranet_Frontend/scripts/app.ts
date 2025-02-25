import { Calendar } from "@fullcalendar/core";
import dayGridPlugin from "@fullcalendar/daygrid";
import timeGridPlugin from "@fullcalendar/timegrid";
import listPlugin from "@fullcalendar/list";
import deLocale from "@fullcalendar/core/locales/de";

document.addEventListener("DOMContentLoaded", () => {
    const searchInput = document.getElementById("input-search") as HTMLInputElement;
    const button = document.getElementById("btn-search");
    const resultDiv = document.getElementById("result-search");
    if (button) {
        button.addEventListener("click", async () => {
            try {
                const searchTerm = searchInput.value.trim();
                if (searchTerm === "" || searchTerm === null) {
                    alert("Bitte Suchfeld füllen!");
                    return;
                }
                const response = await fetch(`/Home/GetMatchingElements?searchTerm=${encodeURIComponent(searchTerm)}`);
                if (response.ok) {
                    document.getElementById("search-result").removeAttribute("hidden");
                } else {
                    alert("Ein Fehler ist aufgetreten.");
                }
            } catch(error) {
                alert("Ein Fehler ist aufgetreten.");
            }
        });
    }
});

// Renders calender
let calendarEl = document.getElementById("calendar");
let calendar = new Calendar(calendarEl, {
    height: 500,
    contentHeight: 50,
    themeSystem: "bootstrap5",
    locale: deLocale,
    plugins: [dayGridPlugin, timeGridPlugin, listPlugin],
    initialView: "dayGridMonth",
    headerToolbar: {
        left: "prev,next today",
        center: "title",
        right: "dayGridMonth,timeGridWeek,listWeek"
    }
});
calendar.render();
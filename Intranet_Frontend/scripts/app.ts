import $ from "jquery";
import "select2";

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
                    resultDiv.removeAttribute("hidden");
                } else {
                    alert("Ein Fehler ist aufgetreten.");
                }
            } catch(error) {
                alert("Ein Fehler ist aufgetreten.");
            }
        });
    }
});

/*
$(function() {
    $("#search-box").select2({
        ajax: {
            url: "/Home/Autocomplete",
            dataType: "json",
            delay: 250, // Prevent too many requests
            data: (params) => ({
                searchTerm: params.term // The search term
            }),
            processResults: (data) => ({
                results: data // Select2 expects { id, text } objects
            })
        },
        minimumInputLength: 2, // Start search after 2 characters
        placeholder: "Search for an item...",
        allowClear: true
    });
});
*/
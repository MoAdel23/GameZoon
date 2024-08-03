


document.addEventListener("DOMContentLoaded", function () {
    $('select').select2({
        placeholder: function () {
            $(this).attr('data-placeholder');
        },
        minimumResultsForSearch: Infinity
    });
})



// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function OnModify() {
    var btnSave = document.querySelector("#btn_enregistrer");
    var field = document.querySelector("#field");
    var btn_modify = document.querySelector("#btn_modify");

    field.removeAttribute("disabled");
    btnSave.setAttribute("style", "display: block;");
    btn_modify.setAttribute("style", "display: none;");
};

var form = document.querySelector("form#formAjoutEval");

form.addEventListener("submit", () => {
    reset(form);
});
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function OnModify() {
    var btnSave = document.querySelector("#btn_enregistrer");
    var btnCancel = document.querySelector("#field");

    btnCancel.setAttribute("disabled", "false")
    btnSave.setAttribute("style", "display: block;")
}
﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//a tipine sahih html kodu demek
//diğeride büyükten küçüğe div alert notification
$(function () {

    if ($("a.confirmDeletion").length) {

        $("a.confirmDeletion").click(() => {
            if (!confirm("Confirm deletetion")) return false;

        });
        
    }
    if ($("div.alert.notification").length) {
        setTimeout(() => {
            $("div.alert.notification").fadeOut();
        }, 2000);
    }

});


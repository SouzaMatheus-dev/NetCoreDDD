(function (msgC, $) {
    "use strict";

    msgC.AdicionarMensagemDeSucesso = function (mensagem) {
        toastr.options = {
            "progressBar": true,
            "positionClass": "toast-top-right"
        };

        toastr.success(mensagem, "");
    };

    msgC.AdicionarMensagemDeErro = function (mensagem) {
        toastr.options = {
            "progressBar": true,
            "positionClass": "toast-top-right"
        };
        toastr.error(mensagem, "");
    };

    msgC.mascaraCNPJ = function mascaraCNPJ(i) {
        var v = i.value;

        // Prevent entering a character other than number
        if (isNaN(v[v.length - 1])) {
            i.value = v.substring(0, v.length - 1);
            return;
        }

        i.setAttribute("maxlength", "18");
        if (v.length == 2 || v.length == 6) i.value += ".";
        if (v.length == 10) i.value += "/";
        if (v.length == 15) i.value += "-";
    };

    msgC.mascaraCPF = function mascaraCPF(i) {
        var v = i.value;

        // Prevent entering a character other than number
        if (isNaN(v[v.length - 1])) {
            i.value = v.substring(0, v.length - 1);
            return;
        }

        i.setAttribute("maxlength", "14");
        if (v.length == 3 || v.length == 7) i.value += ".";
        if (v.length == 11) i.value += "-";
    };
})(window.msgC = window.msgC || {});

function survey(selector, callback) {
    var input = $(selector);
    var oldvalue = input.val();
    setInterval(function () {
        if (input.val() != oldvalue) {
            oldvalue = input.val();
            callback(input);
        }
    }, 100);
}
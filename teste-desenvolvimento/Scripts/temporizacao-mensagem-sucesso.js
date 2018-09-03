(function ($) {
    'use strict';

    $(".alert-success")
                      .fadeTo(2000, 500)
                      .slideUp(500, function () {
                          $(this).remove()
                      });
})($ || jquery);
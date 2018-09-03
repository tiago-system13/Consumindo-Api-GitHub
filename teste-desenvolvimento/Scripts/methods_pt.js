/*
 * Localized default methods for the jQuery validation plugin.
 * Locale: PT_BR
 */
$.extend( $.validator.methods, {
    date: function (value, element) {

		var formatosValidos = [
			'DD/MM/YYYY',
			'DD/MM/YYYY HH:mm',
			'DD/MM/YYYY HH:mm:ss'
		];

		return this.optional(element)
					|| moment(value, formatosValidos, 'pt-br').isValid();
	}
});

$.extend($.validator.methods, {
	number: function (value, element) {
		return this.optional(element)
				   || /^(?:-?\d+|-?\d{1,3}(?:.\d{3})+)?(?:\,\d+)?$/.test(value);
	}
});
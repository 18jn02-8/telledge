$('.agreement-checkbox').click(() => {
	isChecked = true;
	$('.agreement-checkbox').forEach(($element) => {
		if ($element.attr('checked') == undefined) {
			isChecked = false;
		}
	});
	if (isChecked == true) {
		$('#inactivedate-button').attr({
			checked: 'checked'
		});
	};
});
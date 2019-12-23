$(() => {
	$('.agreement-checkbox').click(() => {
		isChecked = true;
		$('.agreement-checkbox').each((i, element) => {
			console.log(element);
			if (!($(element).prop('checked'))) {
				isChecked = false;
			}
		});
		if (isChecked == true) {
			$('#inactivedate-button').removeAttr('disabled');
		} else {
			$('#inactivedate-button').attr({ disabled: 'disabled' });
		};
	});
});

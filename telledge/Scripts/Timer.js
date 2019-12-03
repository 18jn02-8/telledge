function timer() {
	const timers = $('#timer').text();
	var id = setInterval(function () {
		var timer = (parseInt(timers) * 60) - 1;
		var min = timer / 60;
		var sec = timer % 60;
		$('#timer').text(timer);
		if (timer <= 0) {
			clearInterval(id);　//idをclearIntervalで指定している
		}
	}, 1000);
}
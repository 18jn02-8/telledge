class Timer{
	constructor(mintimer, overtimer) {
		super(mintimer, overtimer);
	}
	minTime() {
		var count = 0;
		var id = setInterval(function () {
			mintimer = (parseInt(mintimer) * 60) - count;
			var min = mintimer / 60;
			var sec = mintimer % 60;
			$('#calltime').Text(parseInt(min) + ":" + parseInt(sec));
			count++;
			if (mintimer <= 0) {
				clearInterval(id);　//idをclearIntervalで指定している
				return 0;
			}
		}, 1000);
		return 1;
	}
	overTime() {
		var count = 0;
		var id = setInterval(function () {
			overtimer = (parseInt(overtimer) * 60);
			var min = overtimer / 60;
			var sec = overtimer % 60;
			$('#calltime').Text(parseInt(min) + ":" + parseInt(sec));
			count++;
			if (overtimer < count) {
				clearInterval(id);　//idをclearIntervalで指定している
			}
		}, 1000);
	}

	startTime() {
		flag = minTime();
		if (flag == 0) {
			overTime();
		}
	}
}

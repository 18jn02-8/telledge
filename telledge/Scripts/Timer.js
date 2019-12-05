class Timer{
	constructor(element, mintime, overtime) {
		this.element = element;
		this.mintime = mintime;
		this.overtime = overtime;
	}
	setTimerAsEssential() {
		this.sec = this.mintime;
	}
	setTimerAsExtend() {
		this.sec = this.overtime;
	}
	showTime() {
		const min = this.sec / 60;
		const sec = min * 60 - this.sec;
		this.element.text(parseInt(min) + ":" + parseInt(sec));
	}

	setTimer() {
		let sec = this.sec;
		const interval = setInterval(() => {
			this.sec--;
			this.showTime();
			if (this.sec <= 0) {
				clearInterval(interval); //idをclearIntervalで指定している
			}
		}, 1000);
	}

	minTime() {
		let flag = 0;
		let count = 0;
		var id = setInterval(function () {
			var mintimer = (parseInt(mintime) * 60) - count;
			var min = mintimer / 60;
			var sec = mintimer % 60;
			$('te').text(parseInt(min) + ":" + parseInt(sec));
			count++;
			if (mintimer <= 0) {
				flag = 1;
				clearInterval(id); //idをclearIntervalで指定している
			}
		}, 1000);
		return flag;
	}
	overTime() {
		var count = 0;
		var id = setInterval(function () {
			var overtimer = (parseInt(overtime) * 60);
			var min = count / 60;
			var sec = count % 60;
			$('te').text(parseInt(min) + ":" + parseInt(sec));
			count++;
			if (overtimer < count) {
				clearInterval(id);　//idをclearIntervalで指定している
			}
		}, 1000);
	}

	typeSection(mintime,overtime) {
	}
}

var con = new Timer($('te'), mintime, overtime);
con.setTimerAsEssential();
con.setTimer( )

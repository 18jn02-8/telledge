class Timer{
	constructor(element, mintime, overtime) {
		this.element = element;
		this.mintime = mintime;
		this.overtime = overtime;
		this.status = 0;
	}
	setTimerAsEssential() {
		this.sec = this.mintime * 60;
		this.status = 1;
	}
	setTimerAsExtend() {
		this.sec = this.overtime * 60;
		$('te').css('color', 'red');
		this.status = 2;
	}
	getStatusCode() {
		return this.status;
	}
	getStatusDetail() {
		let ret;
		if (this.status == 0) ret = "Not started";
		else if (this.status == 1) ret = "Essential";
		else if (this.status == 2) ret = "Extend";
		else ret = "All done";
	}
	showTime() {
		const min = this.sec / 60;
		const sec = this.sec % 60;
		$('te').text(parseInt(min) + ":" + parseInt(sec));
	}

	setTimer() {
		let sec = this.sec;
		const interval = setInterval(() => {
			this.sec--;
			this.showTime();
			if (this.sec <= 0) {
				this.status++;
				if (this.status == 1) this.setTimerAsEssential();
				if (this.status == 2) this.setTimerAsExtend();
			}
		}, 1000);
	}
}

var con = new Timer($('te'), mintime, overtime);
con.setTimerAsEssential();	//最低通話として処理
con.setTimer( )

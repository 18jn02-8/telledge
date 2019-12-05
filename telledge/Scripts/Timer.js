class Timer{
	constructor(selector, mintime, overtime) {
		this.selector = selector;
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
		$(this.selector).css('color', 'red');
		this.status = 2;
	}
	getStatusCode() {
		//statusコードを返却する
		return this.status;
	}
	getStatusDetail() {
		//statusに応じた状態を返却する
		let ret;
		if (this.status == 0) ret = "Not started";
		else if (this.status == 1) ret = "Essential";
		else if (this.status == 2) ret = "Extend";
		else ret = "All done";
	}
	showTime() {
		//secを適切な形に変換して表示する
		const min = this.sec / 60;
		const sec = this.sec % 60;
		$(this.selector).text(parseInt(min) + ":" + parseInt(sec));
	}

	setTimer() {
		//secを減らす
		let sec = this.sec;
		const interval = setInterval(() => {
			this.showTime();
			this.sec--;
			if (this.sec < 0) {
				this.status++;
				if (this.status == 1) this.setTimerAsEssential();
				if (this.status == 2) this.setTimerAsExtend();
			}
		}, 1000);
	}
}

var con = new Timer('te', mintime, overtime);
con.setTimerAsEssential();	//最低通話として処理
con.setTimer( )

using System;

	public class StrokeCounter
	{


	public int currentCount;

	public StrokeCounter (){
		this.currentCount = 0;
	}

	public void addStroke(){
		this.currentCount += 1;
	}

	public int getCurrentCount(){
		return this.currentCount;
	}

	public void resetStrokes(){
		this.currentCount = 0;
	}
}


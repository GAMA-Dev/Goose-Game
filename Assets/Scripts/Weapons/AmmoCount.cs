using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCount : MonoBehaviour {

	public int count;
	public int beginningCount;

	public void setCount(int i)
	{
		beginningCount = i;
		count = i;
	}
	public void reduceCount(int j)
	{
		count -= j;
	}
	public void reload()
	{
		count = beginningCount;
	}
}

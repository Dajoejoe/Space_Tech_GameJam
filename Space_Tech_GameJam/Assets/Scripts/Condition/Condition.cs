using UnityEngine;
using System.Collections;
using System;

public delegate void ConditionMet(Condition condition);

public class Condition {
	
	public enum ConditionType {
		Time=1, LiveLoss
	};

	Guid id;
	public ConditionType type;
	public float limit;
	public float amt;

	public ConditionMet metDelegate;

	public Condition(ConditionType type, float limit) {
		this.id = Guid.NewGuid();
		this.type = type;
		this.limit = limit;
	}

	public void AddAmt(float amt) {
		this.amt += amt;
		if (this.amt >= this.limit) {
			if (this.metDelegate != null)
				this.metDelegate(this);
		}
	}

	public bool Equals(Condition condition) {
		return condition.id == this.id;
	}
}

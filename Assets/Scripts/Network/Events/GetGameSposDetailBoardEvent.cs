﻿using UnityEngine;
using System.Collections;

public class GetGameSposDetailBoardEvent : BaseEvent {

	public GetGameSposDetailBoardEvent(EventDelegate eventDelegate)
	{
		base.eventDelegate = eventDelegate;

		InitEvent += InitResponse;
	}

	public void InitResponse(string data)
	{
		response = JsonFx.Json.JsonReader.Deserialize<GetGameSposDetailBoardResponse>(data);

		eventDelegate.Execute ();
	}

	public GetGameSposDetailBoardResponse GetResponse()
	{
		return response as GetGameSposDetailBoardResponse;
	}

}
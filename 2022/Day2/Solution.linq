<Query Kind="Program" />

void Main()
{
	var inputFile = @"PATH_TO_INPUT_FILE";
	
	var firstHandMap = new Dictionary<string,Hand>
	{
		{"A", Hand.Rock},	
		{"B", Hand.Paper},	
		{"C", Hand.Scissor},	
	};

	var secondHandMap = new Dictionary<string, Hand>
	{
		{"X", Hand.Rock},
		{"Y", Hand.Paper},
		{"Z", Hand.Scissor},
	};

	var secondHandScores = new Dictionary<(Hand,Hand), int>
	{
		{(Hand.Rock,Hand.Rock),3},
		{(Hand.Rock,Hand.Paper),0},
		{(Hand.Rock,Hand.Scissor),6},
		
		{(Hand.Paper,Hand.Rock),6},
		{(Hand.Paper,Hand.Paper),1},
		{(Hand.Paper,Hand.Scissor),0},
		
		{(Hand.Scissor,Hand.Rock),6},
		{(Hand.Scissor,Hand.Paper),0},
		{(Hand.Scissor,Hand.Scissor),1},
	};
	var text = File.ReadAllText(inputFile);
	
	var rows = text.Split("\n",StringSplitOptions.RemoveEmptyEntries);

	var roundScores = rows.Select(r =>
	{
		var hands = r.Split(" ");
		var firstHand = firstHandMap[hands[0]];
		var secondHand = secondHandMap[hands[1]];
		
		var roundScore = secondHandScores[(firstHand,secondHand)];
		return roundScore + (int) secondHand;
	}).Dump();
	
	var finalScore = roundScores.Sum().Dump("Final Score");
	
}

enum Hand
{
	Rock = 1,
	Paper = 2,
	Scissor = 3
}
namespace RankingModel;

public record class Player(int skill, int emotionalSkill)
{
    public int Skill { get; set; } = skill;
    public int EmotionalSkill { get; set; } = emotionalSkill;
    public int OffsetSkill { get; set; } = 0;

    public int SkillAfterEmotions
    {
        get
        {
            var value = Skill + EmotionalSkill;
            return value > 0 ? value : 0;
        }
    }

    public int CurrentElo
    {
        get
        {
            var value = SkillAfterEmotions + OffsetSkill;
            return value > 0 ? value : 0;
        }
    }

    public string ToRank()
    {
        return CurrentElo switch
        {
            < 400 => $"Iron: {CurrentElo} Lp",
            < 800 => $"Bronze: {CurrentElo - 400} Lp",
            < 1200 => $"Silver: {CurrentElo - 800} Lp",
            < 1600 => $"Gold: {CurrentElo - 1200} Lp",
            < 2000 => $"Platin: {CurrentElo - 1600} Lp",
            < 2400 => $"Emreald: {CurrentElo - 2000} Lp",
            < 2800 => $"Diamant: {CurrentElo - 2400} Lp",
            < 3200 => $"Master: {CurrentElo - 2800} Lp",
            _ => CurrentElo + " Elo",
        };
    }

    public void PlayGame()
    {
        var random = new Random().Next(0, 1);
        if (random == 0)
        {
            OffsetSkill += 30;
            EmotionalSkill = 0;
        }

        OffsetSkill -= 30;
        EmotionalSkill -= 10;
    }
}
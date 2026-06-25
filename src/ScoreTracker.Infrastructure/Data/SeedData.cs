using ScoreTracker.Core.Models;

namespace ScoreTracker.Infrastructure.Data;

// Group assignments are based on the December 2024 FIFA draw.
// Verify against official FIFA records at https://www.fifa.com/en/tournaments/mens/worldcup/canadamexicousa2026
public static class SeedData
{
    public static void Seed(AppDbContext context)
    {
        if (context.Groups.Any()) return;

        var groups = new List<Group>
        {
            new() { Id = 1, Name = "A" },
            new() { Id = 2, Name = "B" },
            new() { Id = 3, Name = "C" },
            new() { Id = 4, Name = "D" },
            new() { Id = 5, Name = "E" },
            new() { Id = 6, Name = "F" },
            new() { Id = 7, Name = "G" },
            new() { Id = 8, Name = "H" },
            new() { Id = 9, Name = "I" },
            new() { Id = 10, Name = "J" },
            new() { Id = 11, Name = "K" },
            new() { Id = 12, Name = "L" },
        };
        context.Groups.AddRange(groups);

        var teams = new List<Team>
        {
            // Group A
            new() { Id = 1,  Name = "USA",          FifaCode = "USA", Confederation = "CONCACAF", GroupId = 1 },
            new() { Id = 2,  Name = "Panama",        FifaCode = "PAN", Confederation = "CONCACAF", GroupId = 1 },
            new() { Id = 3,  Name = "Albania",       FifaCode = "ALB", Confederation = "UEFA",     GroupId = 1 },
            new() { Id = 4,  Name = "Ukraine",       FifaCode = "UKR", Confederation = "UEFA",     GroupId = 1 },
            // Group B
            new() { Id = 5,  Name = "Mexico",        FifaCode = "MEX", Confederation = "CONCACAF", GroupId = 2 },
            new() { Id = 6,  Name = "Jamaica",       FifaCode = "JAM", Confederation = "CONCACAF", GroupId = 2 },
            new() { Id = 7,  Name = "Venezuela",     FifaCode = "VEN", Confederation = "CONMEBOL", GroupId = 2 },
            new() { Id = 8,  Name = "Ecuador",       FifaCode = "ECU", Confederation = "CONMEBOL", GroupId = 2 },
            // Group C
            new() { Id = 9,  Name = "Canada",        FifaCode = "CAN", Confederation = "CONCACAF", GroupId = 3 },
            new() { Id = 10, Name = "Honduras",      FifaCode = "HON", Confederation = "CONCACAF", GroupId = 3 },
            new() { Id = 11, Name = "New Zealand",   FifaCode = "NZL", Confederation = "OFC",      GroupId = 3 },
            new() { Id = 12, Name = "Portugal",      FifaCode = "POR", Confederation = "UEFA",     GroupId = 3 },
            // Group D
            new() { Id = 13, Name = "Argentina",     FifaCode = "ARG", Confederation = "CONMEBOL", GroupId = 4 },
            new() { Id = 14, Name = "Chile",         FifaCode = "CHI", Confederation = "CONMEBOL", GroupId = 4 },
            new() { Id = 15, Name = "Peru",          FifaCode = "PER", Confederation = "CONMEBOL", GroupId = 4 },
            new() { Id = 16, Name = "Japan",         FifaCode = "JPN", Confederation = "AFC",      GroupId = 4 },
            // Group E
            new() { Id = 17, Name = "Brazil",        FifaCode = "BRA", Confederation = "CONMEBOL", GroupId = 5 },
            new() { Id = 18, Name = "Paraguay",      FifaCode = "PAR", Confederation = "CONMEBOL", GroupId = 5 },
            new() { Id = 19, Name = "Colombia",      FifaCode = "COL", Confederation = "CONMEBOL", GroupId = 5 },
            new() { Id = 20, Name = "Croatia",       FifaCode = "CRO", Confederation = "UEFA",     GroupId = 5 },
            // Group F
            new() { Id = 21, Name = "Germany",       FifaCode = "GER", Confederation = "UEFA",     GroupId = 6 },
            new() { Id = 22, Name = "Poland",        FifaCode = "POL", Confederation = "UEFA",     GroupId = 6 },
            new() { Id = 23, Name = "Costa Rica",    FifaCode = "CRC", Confederation = "CONCACAF", GroupId = 6 },
            new() { Id = 24, Name = "South Korea",   FifaCode = "KOR", Confederation = "AFC",      GroupId = 6 },
            // Group G
            new() { Id = 25, Name = "France",        FifaCode = "FRA", Confederation = "UEFA",     GroupId = 7 },
            new() { Id = 26, Name = "Belgium",       FifaCode = "BEL", Confederation = "UEFA",     GroupId = 7 },
            new() { Id = 27, Name = "Morocco",       FifaCode = "MAR", Confederation = "CAF",      GroupId = 7 },
            new() { Id = 28, Name = "Senegal",       FifaCode = "SEN", Confederation = "CAF",      GroupId = 7 },
            // Group H
            new() { Id = 29, Name = "Spain",         FifaCode = "ESP", Confederation = "UEFA",     GroupId = 8 },
            new() { Id = 30, Name = "Netherlands",   FifaCode = "NED", Confederation = "UEFA",     GroupId = 8 },
            new() { Id = 31, Name = "Egypt",         FifaCode = "EGY", Confederation = "CAF",      GroupId = 8 },
            new() { Id = 32, Name = "Nigeria",       FifaCode = "NGA", Confederation = "CAF",      GroupId = 8 },
            // Group I
            new() { Id = 33, Name = "England",       FifaCode = "ENG", Confederation = "UEFA",     GroupId = 9 },
            new() { Id = 34, Name = "Austria",       FifaCode = "AUT", Confederation = "UEFA",     GroupId = 9 },
            new() { Id = 35, Name = "Switzerland",   FifaCode = "SUI", Confederation = "UEFA",     GroupId = 9 },
            new() { Id = 36, Name = "Iran",          FifaCode = "IRN", Confederation = "AFC",      GroupId = 9 },
            // Group J
            new() { Id = 37, Name = "Italy",         FifaCode = "ITA", Confederation = "UEFA",     GroupId = 10 },
            new() { Id = 38, Name = "Turkey",        FifaCode = "TUR", Confederation = "UEFA",     GroupId = 10 },
            new() { Id = 39, Name = "Georgia",       FifaCode = "GEO", Confederation = "UEFA",     GroupId = 10 },
            new() { Id = 40, Name = "Australia",     FifaCode = "AUS", Confederation = "AFC",      GroupId = 10 },
            // Group K
            new() { Id = 41, Name = "Serbia",        FifaCode = "SRB", Confederation = "UEFA",     GroupId = 11 },
            new() { Id = 42, Name = "Denmark",       FifaCode = "DEN", Confederation = "UEFA",     GroupId = 11 },
            new() { Id = 43, Name = "Czech Republic",FifaCode = "CZE", Confederation = "UEFA",     GroupId = 11 },
            new() { Id = 44, Name = "Saudi Arabia",  FifaCode = "KSA", Confederation = "AFC",      GroupId = 11 },
            // Group L
            new() { Id = 45, Name = "Uruguay",       FifaCode = "URU", Confederation = "CONMEBOL", GroupId = 12 },
            new() { Id = 46, Name = "Bolivia",       FifaCode = "BOL", Confederation = "CONMEBOL", GroupId = 12 },
            new() { Id = 47, Name = "Hungary",       FifaCode = "HUN", Confederation = "UEFA",     GroupId = 12 },
            new() { Id = 48, Name = "DR Congo",      FifaCode = "COD", Confederation = "CAF",      GroupId = 12 },
        };
        context.Teams.AddRange(teams);

        var matches = BuildGroupMatches(teams);
        context.Matches.AddRange(matches);

        var goals = BuildSampleGoals(matches, teams);
        context.Goals.AddRange(goals);

        context.SaveChanges();
    }

    private static List<Match> BuildGroupMatches(List<Team> teams)
    {
        var matches = new List<Match>();
        int matchId = 1;

        // Venues used across the three host nations
        var venues = new[]
        {
            "SoFi Stadium, Los Angeles",
            "MetLife Stadium, New York",
            "AT&T Stadium, Dallas",
            "Estadio Azteca, Mexico City",
            "BC Place, Vancouver",
            "Levi's Stadium, San Francisco",
            "Hard Rock Stadium, Miami",
            "Gillette Stadium, Boston",
            "Estadio BBVA, Monterrey",
            "BMO Field, Toronto",
            "NRG Stadium, Houston",
            "Arrowhead Stadium, Kansas City",
        };

        // Group stage: each team plays the other 3 in its group
        var groupTeams = teams.GroupBy(t => t.GroupId).OrderBy(g => g.Key).ToList();

        // June 11 2026 is the opening day; matches run through 27 June (group stage ends ~27 Jun)
        var baseDate = new DateTime(2026, 6, 11);

        foreach (var group in groupTeams)
        {
            var groupList = group.ToList();
            var venueIndex = group.Key - 1;

            // Round-robin: 3 matchdays, 2 games per matchday
            var pairings = new[] { (0, 1), (2, 3), (0, 2), (1, 3), (0, 3), (1, 2) };

            for (int i = 0; i < pairings.Length; i++)
            {
                var (h, a) = pairings[i];
                int matchdayOffset = (i / 2) * 6; // matchdays spread across 6-day windows
                matches.Add(new Match
                {
                    Id = matchId++,
                    GroupId = group.Key,
                    HomeTeamId = groupList[h].Id,
                    AwayTeamId = groupList[a].Id,
                    KickOff = baseDate.AddDays(matchdayOffset + (group.Key % 3)),
                    Venue = venues[venueIndex % venues.Length],
                    Status = MatchStatus.Scheduled,
                });
            }
        }

        return matches;
    }

    private static List<Goal> BuildSampleGoals(List<Match> matches, List<Team> teams)
    {
        // Seed a handful of completed matches with results so the standings table has data to display.
        var goals = new List<Goal>();
        int goalId = 1;

        void Complete(int matchId, List<(int teamId, string scorer, int min, bool og, bool pen)> goalData)
        {
            var match = matches.FirstOrDefault(m => m.Id == matchId);
            if (match is null) return;

            match.Status = MatchStatus.Completed;
            int homeGoals = goalData.Count(g => g.teamId == match.HomeTeamId && !g.og)
                          + goalData.Count(g => g.teamId == match.AwayTeamId && g.og);
            int awayGoals = goalData.Count(g => g.teamId == match.AwayTeamId && !g.og)
                          + goalData.Count(g => g.teamId == match.HomeTeamId && g.og);
            match.HomeScore = homeGoals;
            match.AwayScore = awayGoals;

            foreach (var (teamId, scorer, min, og, pen) in goalData)
            {
                goals.Add(new Goal
                {
                    Id = goalId++,
                    MatchId = matchId,
                    TeamId = teamId,
                    ScorerName = scorer,
                    Minute = min,
                    IsOwnGoal = og,
                    IsPenalty = pen,
                });
            }
        }

        // Group A — Match 1: USA vs Panama
        Complete(1, new()
        {
            (1, "Pulisic", 23, false, false),
            (1, "Reyna",   67, false, false),
            (2, "Davis",   81, false, false),
        });

        // Group A — Match 2: Albania vs Ukraine
        Complete(2, new()
        {
            (4, "Mudryk",  34, false, false),
            (4, "Zinchenko", 55, false, false),
            (3, "Broja",   78, false, false),
        });

        // Group B — Match 1: Mexico vs Jamaica
        Complete(7, new()
        {
            (5, "Lozano",  12, false, false),
            (5, "Raul",    45, false, true),
            (5, "Herrera", 88, false, false),
        });

        // Group C — Match 1: Canada vs Honduras
        Complete(13, new()
        {
            (9, "Davies",  8,  false, false),
            (9, "David",   52, false, false),
            (10,"Lozano",  71, false, false),
            (9, "Buchanan",90, false, false),
        });

        // Group H — Match 1: Spain vs Netherlands
        Complete(43, new()
        {
            (29, "Yamal",    17, false, false),
            (30, "Gakpo",    38, false, false),
            (29, "Morata",   61, false, false),
            (30, "van Dijk", 85, false, false),
        });

        return goals;
    }
}

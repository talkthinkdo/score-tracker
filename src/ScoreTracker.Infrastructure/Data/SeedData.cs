using ScoreTracker.Core.Models;

namespace ScoreTracker.Infrastructure.Data;

// Data sourced from FIFA 2026 API (standing.json, matches.json) as at 25 June 2026.
// Groups A, B, C are fully complete. Groups D-L have matchday 3 still to play.
// IR Iran 2-2 New Zealand (Group G MD1) is inferred from standings arithmetic.
public static class SeedData
{
    public static void Seed(AppDbContext context)
    {
        if (context.Groups.Any()) return;

        var groups = new List<Group>
        {
            new() { Id = 1,  Name = "A" },
            new() { Id = 2,  Name = "B" },
            new() { Id = 3,  Name = "C" },
            new() { Id = 4,  Name = "D" },
            new() { Id = 5,  Name = "E" },
            new() { Id = 6,  Name = "F" },
            new() { Id = 7,  Name = "G" },
            new() { Id = 8,  Name = "H" },
            new() { Id = 9,  Name = "I" },
            new() { Id = 10, Name = "J" },
            new() { Id = 11, Name = "K" },
            new() { Id = 12, Name = "L" },
        };
        context.Groups.AddRange(groups);

        var teams = new List<Team>
        {
            // Group A
            new() { Id = 1,  Name = "Mexico",                FifaCode = "MEX", Confederation = "CONCACAF", GroupId = 1  },
            new() { Id = 2,  Name = "South Africa",           FifaCode = "RSA", Confederation = "CAF",      GroupId = 1  },
            new() { Id = 3,  Name = "Korea Republic",         FifaCode = "KOR", Confederation = "AFC",      GroupId = 1  },
            new() { Id = 4,  Name = "Czechia",                FifaCode = "CZE", Confederation = "UEFA",     GroupId = 1  },
            // Group B
            new() { Id = 5,  Name = "Switzerland",            FifaCode = "SUI", Confederation = "UEFA",     GroupId = 2  },
            new() { Id = 6,  Name = "Canada",                 FifaCode = "CAN", Confederation = "CONCACAF", GroupId = 2  },
            new() { Id = 7,  Name = "Bosnia and Herzegovina", FifaCode = "BIH", Confederation = "UEFA",     GroupId = 2  },
            new() { Id = 8,  Name = "Qatar",                  FifaCode = "QAT", Confederation = "AFC",      GroupId = 2  },
            // Group C
            new() { Id = 9,  Name = "Brazil",                 FifaCode = "BRA", Confederation = "CONMEBOL", GroupId = 3  },
            new() { Id = 10, Name = "Morocco",                FifaCode = "MAR", Confederation = "CAF",      GroupId = 3  },
            new() { Id = 11, Name = "Scotland",               FifaCode = "SCO", Confederation = "UEFA",     GroupId = 3  },
            new() { Id = 12, Name = "Haiti",                  FifaCode = "HAI", Confederation = "CONCACAF", GroupId = 3  },
            // Group D
            new() { Id = 13, Name = "USA",                    FifaCode = "USA", Confederation = "CONCACAF", GroupId = 4  },
            new() { Id = 14, Name = "Australia",              FifaCode = "AUS", Confederation = "AFC",      GroupId = 4  },
            new() { Id = 15, Name = "Paraguay",               FifaCode = "PAR", Confederation = "CONMEBOL", GroupId = 4  },
            new() { Id = 16, Name = "Türkiye",                FifaCode = "TUR", Confederation = "UEFA",     GroupId = 4  },
            // Group E
            new() { Id = 17, Name = "Germany",                FifaCode = "GER", Confederation = "UEFA",     GroupId = 5  },
            new() { Id = 18, Name = "Côte d'Ivoire",          FifaCode = "CIV", Confederation = "CAF",      GroupId = 5  },
            new() { Id = 19, Name = "Ecuador",                FifaCode = "ECU", Confederation = "CONMEBOL", GroupId = 5  },
            new() { Id = 20, Name = "Curaçao",                FifaCode = "CUW", Confederation = "CONCACAF", GroupId = 5  },
            // Group F
            new() { Id = 21, Name = "Netherlands",            FifaCode = "NED", Confederation = "UEFA",     GroupId = 6  },
            new() { Id = 22, Name = "Japan",                  FifaCode = "JPN", Confederation = "AFC",      GroupId = 6  },
            new() { Id = 23, Name = "Sweden",                 FifaCode = "SWE", Confederation = "UEFA",     GroupId = 6  },
            new() { Id = 24, Name = "Tunisia",                FifaCode = "TUN", Confederation = "CAF",      GroupId = 6  },
            // Group G
            new() { Id = 25, Name = "Belgium",                FifaCode = "BEL", Confederation = "UEFA",     GroupId = 7  },
            new() { Id = 26, Name = "Egypt",                  FifaCode = "EGY", Confederation = "CAF",      GroupId = 7  },
            new() { Id = 27, Name = "IR Iran",                FifaCode = "IRN", Confederation = "AFC",      GroupId = 7  },
            new() { Id = 28, Name = "New Zealand",            FifaCode = "NZL", Confederation = "OFC",      GroupId = 7  },
            // Group H
            new() { Id = 29, Name = "Spain",                  FifaCode = "ESP", Confederation = "UEFA",     GroupId = 8  },
            new() { Id = 30, Name = "Uruguay",                FifaCode = "URU", Confederation = "CONMEBOL", GroupId = 8  },
            new() { Id = 31, Name = "Cabo Verde",             FifaCode = "CPV", Confederation = "CAF",      GroupId = 8  },
            new() { Id = 32, Name = "Saudi Arabia",           FifaCode = "KSA", Confederation = "AFC",      GroupId = 8  },
            // Group I
            new() { Id = 33, Name = "France",                 FifaCode = "FRA", Confederation = "UEFA",     GroupId = 9  },
            new() { Id = 34, Name = "Norway",                 FifaCode = "NOR", Confederation = "UEFA",     GroupId = 9  },
            new() { Id = 35, Name = "Senegal",                FifaCode = "SEN", Confederation = "CAF",      GroupId = 9  },
            new() { Id = 36, Name = "Iraq",                   FifaCode = "IRQ", Confederation = "AFC",      GroupId = 9  },
            // Group J
            new() { Id = 37, Name = "Argentina",              FifaCode = "ARG", Confederation = "CONMEBOL", GroupId = 10 },
            new() { Id = 38, Name = "Austria",                FifaCode = "AUT", Confederation = "UEFA",     GroupId = 10 },
            new() { Id = 39, Name = "Algeria",                FifaCode = "ALG", Confederation = "CAF",      GroupId = 10 },
            new() { Id = 40, Name = "Jordan",                 FifaCode = "JOR", Confederation = "AFC",      GroupId = 10 },
            // Group K
            new() { Id = 41, Name = "Colombia",               FifaCode = "COL", Confederation = "CONMEBOL", GroupId = 11 },
            new() { Id = 42, Name = "Portugal",               FifaCode = "POR", Confederation = "UEFA",     GroupId = 11 },
            new() { Id = 43, Name = "Congo DR",               FifaCode = "COD", Confederation = "CAF",      GroupId = 11 },
            new() { Id = 44, Name = "Uzbekistan",             FifaCode = "UZB", Confederation = "AFC",      GroupId = 11 },
            // Group L
            new() { Id = 45, Name = "England",                FifaCode = "ENG", Confederation = "UEFA",     GroupId = 12 },
            new() { Id = 46, Name = "Ghana",                  FifaCode = "GHA", Confederation = "CAF",      GroupId = 12 },
            new() { Id = 47, Name = "Croatia",                FifaCode = "CRO", Confederation = "UEFA",     GroupId = 12 },
            new() { Id = 48, Name = "Panama",                 FifaCode = "PAN", Confederation = "CONCACAF", GroupId = 12 },
        };
        context.Teams.AddRange(teams);

        context.Matches.AddRange(BuildMatches());

        context.SaveChanges();
    }

    private static List<Match> BuildMatches()
    {
        var matches = new List<Match>();
        int id = 0;

        Match Done(int groupId, int home, int away, DateTime kickOff, string venue, int homeScore, int awayScore)
        {
            id++;
            return new Match
            {
                Id = id,
                GroupId = groupId,
                HomeTeamId = home,
                AwayTeamId = away,
                KickOff = kickOff,
                Venue = venue,
                Status = MatchStatus.Completed,
                HomeScore = homeScore,
                AwayScore = awayScore,
            };
        }

        Match Soon(int groupId, int home, int away, DateTime kickOff, string venue)
        {
            id++;
            return new Match
            {
                Id = id,
                GroupId = groupId,
                HomeTeamId = home,
                AwayTeamId = away,
                KickOff = kickOff,
                Venue = venue,
                Status = MatchStatus.Scheduled,
            };
        }

        DateTime Utc(int mo, int d, int h, int mi = 0) =>
            new(2026, mo, d, h, mi, 0, DateTimeKind.Utc);

        // ── Group A — all three matchdays complete ───────────────────────────────────
        // Team IDs: Mexico=1, South Africa=2, Korea Republic=3, Czechia=4
        matches.Add(Done( 1,  1,  2, Utc( 6, 11, 19),    "Estadio Azteca, Mexico City",           2, 0));
        matches.Add(Done( 1,  3,  4, Utc( 6, 12,  2),    "NRG Stadium, Houston",                  2, 1));
        matches.Add(Done( 1,  4,  2, Utc( 6, 18, 16),    "Estadio Azteca, Mexico City",           1, 1));
        matches.Add(Done( 1,  1,  3, Utc( 6, 19,  1),    "Arrowhead Stadium, Kansas City",        1, 0));
        matches.Add(Done( 1,  4,  1, Utc( 6, 25,  1),    "Estadio BBVA, Monterrey",               0, 3));
        matches.Add(Done( 1,  2,  3, Utc( 6, 25,  1),    "NRG Stadium, Houston",                  1, 0));

        // ── Group B — all three matchdays complete ───────────────────────────────────
        // Switzerland=5, Canada=6, Bosnia and Herzegovina=7, Qatar=8
        matches.Add(Done( 2,  6,  7, Utc( 6, 12, 19),    "BC Place, Vancouver",                   1, 1));
        matches.Add(Done( 2,  8,  5, Utc( 6, 13, 19),    "BMO Field, Toronto",                    1, 1));
        matches.Add(Done( 2,  5,  7, Utc( 6, 18, 19),    "BC Place, Vancouver",                   4, 1));
        matches.Add(Done( 2,  6,  8, Utc( 6, 18, 22),    "BMO Field, Toronto",                    6, 0));
        matches.Add(Done( 2,  5,  6, Utc( 6, 24, 19),    "BC Place, Vancouver",                   2, 1));
        matches.Add(Done( 2,  7,  8, Utc( 6, 24, 19),    "BMO Field, Toronto",                    3, 1));

        // ── Group C — all three matchdays complete ───────────────────────────────────
        // Brazil=9, Morocco=10, Scotland=11, Haiti=12
        matches.Add(Done( 3,  9, 10, Utc( 6, 13, 22),    "MetLife Stadium, New York",             1, 1));
        matches.Add(Done( 3, 12, 11, Utc( 6, 14,  1),    "Hard Rock Stadium, Miami",              0, 1));
        matches.Add(Done( 3, 11, 10, Utc( 6, 19, 22),    "MetLife Stadium, New York",             0, 1));
        matches.Add(Done( 3,  9, 12, Utc( 6, 20,  0, 30),"Gillette Stadium, Boston",             3, 0));
        matches.Add(Done( 3, 10, 12, Utc( 6, 24, 22),    "MetLife Stadium, New York",             4, 2));
        matches.Add(Done( 3, 11,  9, Utc( 6, 24, 22),    "Hard Rock Stadium, Miami",              0, 3));

        // ── Group D — matchday 3 still to play ──────────────────────────────────────
        // USA=13, Australia=14, Paraguay=15, Türkiye=16
        matches.Add(Done( 4, 13, 15, Utc( 6, 13,  1),    "SoFi Stadium, Los Angeles",             4, 1));
        matches.Add(Done( 4, 14, 16, Utc( 6, 14,  4),    "AT&T Stadium, Dallas",                  2, 0));
        matches.Add(Done( 4, 13, 14, Utc( 6, 19, 19),    "SoFi Stadium, Los Angeles",             2, 0));
        matches.Add(Done( 4, 16, 15, Utc( 6, 20,  3),    "AT&T Stadium, Dallas",                  0, 1));
        matches.Add(Soon( 4, 16, 13, Utc( 6, 26,  2),    "SoFi Stadium, Los Angeles"));
        matches.Add(Soon( 4, 15, 14, Utc( 6, 26,  2),    "AT&T Stadium, Dallas"));

        // ── Group E — matchday 3 still to play ──────────────────────────────────────
        // Germany=17, Côte d'Ivoire=18, Ecuador=19, Curaçao=20
        matches.Add(Done( 5, 17, 20, Utc( 6, 14, 17),    "Levi's Stadium, San Francisco",         7, 1));
        matches.Add(Done( 5, 18, 19, Utc( 6, 14, 23),    "Arrowhead Stadium, Kansas City",        1, 0));
        matches.Add(Done( 5, 17, 18, Utc( 6, 20, 20),    "Levi's Stadium, San Francisco",         2, 1));
        matches.Add(Done( 5, 19, 20, Utc( 6, 21,  0),    "Arrowhead Stadium, Kansas City",        0, 0));
        matches.Add(Soon( 5, 19, 17, Utc( 6, 25, 20),    "Levi's Stadium, San Francisco"));
        matches.Add(Soon( 5, 20, 18, Utc( 6, 25, 20),    "Arrowhead Stadium, Kansas City"));

        // ── Group F — matchday 3 still to play ──────────────────────────────────────
        // Netherlands=21, Japan=22, Sweden=23, Tunisia=24
        matches.Add(Done( 6, 21, 22, Utc( 6, 14, 20),    "Lincoln Financial Field, Philadelphia",  2, 2));
        matches.Add(Done( 6, 23, 24, Utc( 6, 15,  2),    "Camping World Stadium, Orlando",         5, 1));
        matches.Add(Done( 6, 21, 23, Utc( 6, 20, 17),    "Lincoln Financial Field, Philadelphia",  5, 1));
        matches.Add(Done( 6, 24, 22, Utc( 6, 21,  4),    "Camping World Stadium, Orlando",         0, 4));
        matches.Add(Soon( 6, 24, 21, Utc( 6, 25, 23),    "Lincoln Financial Field, Philadelphia"));
        matches.Add(Soon( 6, 22, 23, Utc( 6, 25, 23),    "Camping World Stadium, Orlando"));

        // ── Group G — matchday 3 still to play ──────────────────────────────────────
        // Belgium=25, Egypt=26, IR Iran=27, New Zealand=28
        // Note: IR Iran 2-2 NZ score inferred from standings (both teams drawn 1, all F/A totals check out)
        matches.Add(Done( 7, 25, 26, Utc( 6, 15, 19),    "Estadio Akron, Guadalajara",             1, 1));
        matches.Add(Done( 7, 27, 28, Utc( 6, 15, 22),    "Estadio Akron, Guadalajara",             2, 2));
        matches.Add(Done( 7, 25, 27, Utc( 6, 21, 19),    "Camping World Stadium, Orlando",         0, 0));
        matches.Add(Done( 7, 28, 26, Utc( 6, 22,  1),    "Estadio Akron, Guadalajara",             1, 3));
        matches.Add(Soon( 7, 25, 28, Utc( 6, 27,  3),    "Camping World Stadium, Orlando"));
        matches.Add(Soon( 7, 26, 27, Utc( 6, 27,  3),    "Estadio Akron, Guadalajara"));

        // ── Group H — matchday 3 still to play ──────────────────────────────────────
        // Spain=29, Uruguay=30, Cabo Verde=31, Saudi Arabia=32
        matches.Add(Done( 8, 29, 31, Utc( 6, 15, 16),    "MetLife Stadium, New York",              0, 0));
        matches.Add(Done( 8, 32, 30, Utc( 6, 15, 22),    "SoFi Stadium, Los Angeles",              1, 1));
        matches.Add(Done( 8, 29, 32, Utc( 6, 21, 16),    "MetLife Stadium, New York",              4, 0));
        matches.Add(Done( 8, 30, 31, Utc( 6, 21, 22),    "SoFi Stadium, Los Angeles",              2, 2));
        matches.Add(Soon( 8, 31, 32, Utc( 6, 27,  0),    "MetLife Stadium, New York"));
        matches.Add(Soon( 8, 30, 29, Utc( 6, 27,  0),    "SoFi Stadium, Los Angeles"));

        // ── Group I — matchday 3 still to play ──────────────────────────────────────
        // France=33, Norway=34, Senegal=35, Iraq=36
        matches.Add(Done( 9, 33, 35, Utc( 6, 16, 19),    "AT&T Stadium, Dallas",                   3, 1));
        matches.Add(Done( 9, 36, 34, Utc( 6, 16, 22),    "Levi's Stadium, San Francisco",          1, 4));
        matches.Add(Done( 9, 33, 36, Utc( 6, 22, 21),    "AT&T Stadium, Dallas",                   3, 0));
        matches.Add(Done( 9, 34, 35, Utc( 6, 23,  0),    "Levi's Stadium, San Francisco",          3, 2));
        matches.Add(Soon( 9, 35, 36, Utc( 6, 26, 19),    "AT&T Stadium, Dallas"));
        matches.Add(Soon( 9, 34, 33, Utc( 6, 26, 19),    "Levi's Stadium, San Francisco"));

        // ── Group J — matchday 3 still to play ──────────────────────────────────────
        // Argentina=37, Austria=38, Algeria=39, Jordan=40
        matches.Add(Done(10, 37, 39, Utc( 6, 17,  1),    "BC Place, Vancouver",                    3, 0));
        matches.Add(Done(10, 38, 40, Utc( 6, 17,  4),    "BMO Field, Toronto",                     3, 1));
        matches.Add(Done(10, 37, 38, Utc( 6, 22, 17),    "BC Place, Vancouver",                    2, 0));
        matches.Add(Done(10, 40, 39, Utc( 6, 23,  3),    "BMO Field, Toronto",                     1, 2));
        matches.Add(Soon(10, 39, 38, Utc( 6, 28,  2),    "BC Place, Vancouver"));
        matches.Add(Soon(10, 40, 37, Utc( 6, 28,  2),    "BMO Field, Toronto"));

        // ── Group K — matchday 3 still to play ──────────────────────────────────────
        // Colombia=41, Portugal=42, Congo DR=43, Uzbekistan=44
        matches.Add(Done(11, 42, 43, Utc( 6, 17, 17),    "Estadio Azteca, Mexico City",            1, 1));
        matches.Add(Done(11, 44, 41, Utc( 6, 18,  2),    "Estadio BBVA, Monterrey",                1, 3));
        matches.Add(Done(11, 42, 44, Utc( 6, 23, 17),    "Estadio Azteca, Mexico City",            5, 0));
        matches.Add(Done(11, 41, 43, Utc( 6, 24,  2),    "Estadio BBVA, Monterrey",                1, 0));
        matches.Add(Soon(11, 41, 42, Utc( 6, 27, 23, 30),"Estadio Azteca, Mexico City"));
        matches.Add(Soon(11, 43, 44, Utc( 6, 27, 23, 30),"Estadio BBVA, Monterrey"));

        // ── Group L — matchday 3 still to play ──────────────────────────────────────
        // England=45, Ghana=46, Croatia=47, Panama=48
        matches.Add(Done(12, 45, 47, Utc( 6, 17, 20),    "Arrowhead Stadium, Kansas City",         4, 2));
        matches.Add(Done(12, 46, 48, Utc( 6, 17, 23),    "Gillette Stadium, Boston",               1, 0));
        matches.Add(Done(12, 45, 46, Utc( 6, 23, 20),    "Arrowhead Stadium, Kansas City",         0, 0));
        matches.Add(Done(12, 48, 47, Utc( 6, 23, 23),    "Gillette Stadium, Boston",               0, 1));
        matches.Add(Soon(12, 47, 46, Utc( 6, 27, 21),    "Arrowhead Stadium, Kansas City"));
        matches.Add(Soon(12, 48, 45, Utc( 6, 27, 21),    "Gillette Stadium, Boston"));

        return matches;
    }
}

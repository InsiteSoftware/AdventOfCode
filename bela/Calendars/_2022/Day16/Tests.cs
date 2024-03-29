﻿namespace Calendars._2022.Day16;

[TestFixture]
public class Tests
{
    [Test]
    public void BasicFirstPart()
    {
        DoWork.FirstPart(basicInput).Should().Be(1651);
    }

    [Test]
    public void FileFirstPart()
    {
        DoWork.FirstPart(fileInput).Should().Be(2183);
    }

    [Test]
    public void BasicSecondPart()
    {
        DoWork.SecondPart(basicInput).Should().Be(1707);
    }

    [Test]
    public void FileSecondPart()
    {
        DoWork.SecondPart(fileInput).Should().Be(1234);
    }

    private static readonly string basicInput =
        @"Valve AA has flow rate=0; tunnels lead to valves DD, II, BB
Valve BB has flow rate=13; tunnels lead to valves CC, AA
Valve CC has flow rate=2; tunnels lead to valves DD, BB
Valve DD has flow rate=20; tunnels lead to valves CC, AA, EE
Valve EE has flow rate=3; tunnels lead to valves FF, DD
Valve FF has flow rate=0; tunnels lead to valves EE, GG
Valve GG has flow rate=0; tunnels lead to valves FF, HH
Valve HH has flow rate=22; tunnel leads to valve GG
Valve II has flow rate=0; tunnels lead to valves AA, JJ
Valve JJ has flow rate=21; tunnel leads to valve II";

    private static readonly string fileInput =
        @"Valve NA has flow rate=0; tunnels lead to valves MU, PH
Valve NW has flow rate=0; tunnels lead to valves KB, MH
Valve MR has flow rate=0; tunnels lead to valves GC, FI
Valve XD has flow rate=0; tunnels lead to valves UN, CN
Valve HK has flow rate=0; tunnels lead to valves AA, IF
Valve JL has flow rate=0; tunnels lead to valves IF, WB
Valve RQ has flow rate=13; tunnels lead to valves BL, DJ
Valve AB has flow rate=0; tunnels lead to valves BO, RU
Valve PE has flow rate=0; tunnels lead to valves AZ, IF
Valve QF has flow rate=0; tunnels lead to valves TD, AZ
Valve BA has flow rate=0; tunnels lead to valves RF, GU
Valve SY has flow rate=0; tunnels lead to valves MH, MU
Valve NT has flow rate=0; tunnels lead to valves DJ, UN
Valve GU has flow rate=21; tunnels lead to valves VJ, BA, YP
Valve AZ has flow rate=12; tunnels lead to valves QF, PI, AS, PE
Valve WQ has flow rate=23; tunnels lead to valves VJ, UM, CN
Valve DR has flow rate=0; tunnels lead to valves GA, CQ
Valve UM has flow rate=0; tunnels lead to valves IE, WQ
Valve XI has flow rate=0; tunnels lead to valves IE, IF
Valve SS has flow rate=0; tunnels lead to valves CQ, MH
Valve IE has flow rate=22; tunnels lead to valves YP, UM, XI, XA
Valve BT has flow rate=24; tunnels lead to valves KB, BL, GA
Valve GA has flow rate=0; tunnels lead to valves DR, BT
Valve AR has flow rate=0; tunnels lead to valves IF, FI
Valve DJ has flow rate=0; tunnels lead to valves RQ, NT
Valve PI has flow rate=0; tunnels lead to valves FI, AZ
Valve WB has flow rate=0; tunnels lead to valves TD, JL
Valve OQ has flow rate=0; tunnels lead to valves ME, TD
Valve RU has flow rate=19; tunnel leads to valve AB
Valve IF has flow rate=7; tunnels lead to valves AR, JL, HK, PE, XI
Valve BO has flow rate=0; tunnels lead to valves ME, AB
Valve CN has flow rate=0; tunnels lead to valves WQ, XD
Valve HH has flow rate=0; tunnels lead to valves AA, FS
Valve AS has flow rate=0; tunnels lead to valves AA, AZ
Valve FS has flow rate=0; tunnels lead to valves HH, MH
Valve PQ has flow rate=0; tunnels lead to valves TD, AA
Valve AA has flow rate=0; tunnels lead to valves HH, CO, AS, HK, PQ
Valve ME has flow rate=18; tunnels lead to valves OQ, BO, PH
Valve RF has flow rate=0; tunnels lead to valves UN, BA
Valve MH has flow rate=8; tunnels lead to valves FS, NW, SS, SY
Valve YP has flow rate=0; tunnels lead to valves IE, GU
Valve FI has flow rate=11; tunnels lead to valves PI, MR, AR, CO, DI
Valve UU has flow rate=0; tunnels lead to valves CQ, MU
Valve CO has flow rate=0; tunnels lead to valves AA, FI
Valve TD has flow rate=16; tunnels lead to valves QF, GC, OQ, WB, PQ
Valve MU has flow rate=15; tunnels lead to valves SY, UU, NA
Valve BL has flow rate=0; tunnels lead to valves BT, RQ
Valve PH has flow rate=0; tunnels lead to valves ME, NA
Valve XA has flow rate=0; tunnels lead to valves IE, DI
Valve GC has flow rate=0; tunnels lead to valves TD, MR
Valve KB has flow rate=0; tunnels lead to valves BT, NW
Valve DI has flow rate=0; tunnels lead to valves XA, FI
Valve CQ has flow rate=9; tunnels lead to valves UU, DR, SS
Valve VJ has flow rate=0; tunnels lead to valves WQ, GU
Valve UN has flow rate=20; tunnels lead to valves NT, XD, RF";
}

interface HabitA {
  name: string;
  isAchived: boolean;
  archivedAt?: Date;
  archivedReason?: string;
}

type HabitB = {status: "active"; name: string} | { status: "archived"; name: string; archivedAd: Date; reason: string};

// interface vs Type
// both will compile, one is nonsense.

const bad: HabitA = {
  name: "Read",
  isAchived: false,
  archivedAt: new Date()
}

const good: HabitB = {status: "active", name: "Read"};

function describeA(h: HabitA): string {
  if (h.isAchived){
    return `${h.name} archived at ${h.archivedAt?.toISOString()}`
  }
  return `${h.name} is active`;
}

function describeB(h: HabitB): string {
  if (h.status === 'archived') {
    // archivedAt is 'Date' no optional chaining needed, it's guaranteed to be of type Date
    return `${h.name} archived at ${h.archivedAd.toISOString()}`;
  }
  return `${h.name} is active`;
}

console.log(describeA(bad));
console.log(describeB(good));


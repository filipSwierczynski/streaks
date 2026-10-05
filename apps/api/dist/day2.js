// interface vs Type
// both will compile, one is nonsense.
const bad = {
    name: "Read",
    isAchived: false,
    archivedAt: new Date()
};
const good = { status: "active", name: "Read" };
function describeA(h) {
    if (h.isAchived) {
        return `${h.name} archived at ${h.archivedAt?.toISOString()}`;
    }
    return `${h.name} is active`;
}
function describeB(h) {
    if (h.status === 'archived') {
        // archivedAt is 'Date' no optional chaining needed, it's guaranteed to be of type Date
        return `${h.name} archived at ${h.archivedAd.toISOString()}`;
    }
    return `${h.name} is active`;
}
console.log(describeA(bad));
console.log(describeB(good));
export {};
//# sourceMappingURL=day2.js.map
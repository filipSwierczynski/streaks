type PaymentStatus = {status: "due", dueDate: number, amount: number} | {status: "paid", paidOn: number, }

const paidFor: PaymentStatus = {
  status: "paid",
  paidOn: new Date().getDate()
}

const unpaid: PaymentStatus = {
  status: "due",
  dueDate: new Date().getDate(),
  amount: 100
}

function describeDue(p: PaymentStatus): string {

  if(p.status === 'due'){
    return `You still owe us ${p.amount} you foocking dickhead, pay up before ${p.dueDate} or we gonna bust your kneecaps`
  }
  return `Thanks for making a payment on ${p.paidOn}`
}

console.log(describeDue(paidFor))

console.log(describeDue(unpaid))

function solve(input) {
    var maxSum = Number(input[0]),
        prices = input.slice(1).map(Number);

    function findMaxSum(prices, maxSum) {
        var sol, mySol, i, myFinalSol;

        sol = new Array(prices.length);
        mySol = new Array(prices.length);

        /* ---------------------------
          Base cases
          --------------------------- */
        if (maxSum === 0) {
            return (0);
        }

        /* ==============================================
          Divide and conquer procedure
          ============================================== */
        /* ---------------------------------------
          Solve the appropriate smaller problems
          --------------------------------------- */
        for (i = 0; i < prices.length; i++) {
            if (maxSum >= prices[i])
                sol[i] = findMaxSum(prices, maxSum - prices[i]);
            else
                sol[i] = 0;
        }

        /* ---------------------------------------------
          Use the solutions to the smaller problems
          to solve original problem
          --------------------------------------------- */
        for (i = 0; i < prices.length; i++) {
            if (maxSum >= prices[i])
                mySol[i] = sol[i] + prices[i];
            else
                mySol[i] = 0;
        }

        /* *************************
          Find the best (maximum)
          ************************* */
        myFinalSol = mySol[0];
        for (i = 1; i < prices.length; i++)
            if (mySol[i] > myFinalSol)
                myFinalSol = mySol[i];

        return myFinalSol;
    }
    return findMaxSum(prices, maxSum);
}
var test1 = [
    '110',
    '19',
    '29',
    '39'
];

console.log(solve(test1));

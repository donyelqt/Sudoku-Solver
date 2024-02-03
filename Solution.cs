public class Solution {
    public void SolveSudoku(char[][] board) {
        Solve(board);
    }

    private bool Solve(char[][] board) {
        for (int row = 0; row < 9; row++) {
            for (int col = 0; col < 9; col++) {
                if (board[row][col] == '.') {
                    for (char num = '1'; num <= '9'; num++) {
                        if (IsValid(board, row, col, num)) {
                            board[row][col] = num;

                            if (Solve(board)) {
                                return true;
                            }

                            // Backtrack if the current choice doesn't lead to a solution
                            board[row][col] = '.';
                        }
                    }
                    // If no valid number is found, return false
                    return false;
                }
            }
        }
        // The entire board is filled, and all constraints are satisfied
        return true;
    }

    private bool IsValid(char[][] board, int row, int col, char num) {
        // Check if 'num' is not present in the current row and column
        for (int i = 0; i < 9; i++) {
            if (board[row][i] == num || board[i][col] == num) {
                return false;
            }
        }

        // Check if 'num' is not present in the current 3x3 subgrid
        int startRow = 3 * (row / 3);
        int startCol = 3 * (col / 3);
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                if (board[startRow + i][startCol + j] == num) {
                    return false;
                }
            }
        }

        return true;
    }
}

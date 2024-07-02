/**
 *author: Dan Arnaiz
 *Bubble Sort Algorithm
 */

 
import java.util.Scanner;

public class Sorting {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        String[][] orders = new String[5][2]; 

        // Input for Order ID and Order Total
        for (int i = 0; i < 5; i++) {
            System.out.println("***  Enter Order ID for order no. " + (i + 1) + ":");
            orders[i][0] = scanner.next(); // Order ID
            System.out.print(">>>  Order Total for " + orders[i][0] + ": ");
            while (!scanner.hasNextDouble()) { // Check if the next input is a double
                System.out.println("~~~ Please enter a valid total amount for "+ orders[i][0] + " ~~~");
                System.out.print(">>>  Order Total for " + orders[i][0] + ": ");
                scanner.next();
            }
            orders[i][1] = scanner.next(); // Order Total
        }
        System.out.println("");
        System.out.println("***  Sorting in progress...  ***");

        // Bubble Sort based on Order Total
        for (int i = 0; i < orders.length - 1; i++) {
            for (int j = 0; j < orders.length - i - 1; j++) {
                if (Double.parseDouble(orders[j][1]) > Double.parseDouble(orders[j + 1][1])) {
                    // Swap orders[j] and orders[j+1]
                    String[] temp = orders[j];
                    orders[j] = orders[j + 1];
                    orders[j + 1] = temp;
                }
            }
            // Print each step of the sorting process
            System.out.println("After pass " + (i + 1) + ":");
            printOrders(orders);
        }
    }

    // Method to print orders
    private static void printOrders(String[][] orders) {
        for (String[] order : orders) {
            System.out.println("Order ID: " + order[0] + ", Order Total: " + order[1]);
        }
        System.out.println();
    }
}
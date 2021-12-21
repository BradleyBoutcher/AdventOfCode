package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
)

// readLines reads a whole file into memory
// and returns a slice of its lines.
func readLines(path string) ([]string, error) {
	file, err := os.Open(path)
	if err != nil {
		return nil, err
	}
	defer file.Close()

	var lines []string
	scanner := bufio.NewScanner(file)
	for scanner.Scan() {
		lines = append(lines, scanner.Text())
	}
	return lines, scanner.Err()
}

func getInput(day string) []string {
	input := fmt.Sprintf("input/day%s.txt", day)

	values, err := readLines(input)
	if err != nil {
		log.Fatal(err)
	}

	return values
}
func answer(message string, answer int) {
	fmt.Printf("\t * %s : %d \n", message, answer)
}

func answer_64(message string, answer int64) {
	fmt.Printf("\t * %s : %d \n", message, answer)
}

func debug(message string, value string) {
	fmt.Printf("\t \t # %s : %s \n", message, value)
}

func debug_64(message string, value int64) {
	fmt.Printf("\t \t # %s : %s \n", message, value)
}

func title(message string) {
	fmt.Printf("---- %s ---- \n", message)
}

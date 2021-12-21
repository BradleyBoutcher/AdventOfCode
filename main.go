package main

import (
	"fmt"
	"strconv"
	"strings"
)

func main() {
	title("Running Advent of Code Challenges...")
	DayOne()
	DayOne_Two()
	DayTwo()
	DayTwo_Two()
	DayThree()
}

func DayOne() {
	title("Day 1: Submarine Depths")

	values := getInput("one")

	prevValue := 0
	increases := -1

	// Iterate through all values
	// and check size against previous value
	for _, s := range values {
		curVal, _ := strconv.Atoi(s)
		if curVal > prevValue {
			increases += 1
		}
		prevValue = curVal
	}

	answer("Total Increases in Depth", increases)
}

func DayOne_Two() {
	title("Day 1 Part 2: Submarine Window Depth")

	values := getInput("one_two")

	prevValue := 0
	increases := -1

	for i := 0; i < len(values)-2; i++ {
		// Sum the three consecutive values
		curVal, _ := strconv.Atoi(values[i])
		secVal, _ := strconv.Atoi(values[i+1])
		thirdVal, _ := strconv.Atoi(values[i+2])

		// check if the three consecutive values
		// have a higher total value than the previous three
		// consecutive values
		total := curVal + secVal + thirdVal
		if total > prevValue {
			increases += 1
		}
		prevValue = total
	}
	answer("Total Increases in Depth", increases)
}

func DayTwo() {
	title("Day Two: Submarine Navigation")

	values := getInput("two")

	x := 0
	y := 0

	for _, s := range values {
		navigation := strings.Split(s, " ")
		distance, _ := strconv.Atoi(navigation[1])
		switch navigation[0] {
		case "forward":
			x += distance
		case "up":
			y -= distance
		case "down":
			y += distance
		}
	}

	total := x * y
	answer("Total Distance Traveled", total)
}

func DayTwo_Two() {
	title("Day 2 Part 2: Submarine Window Depths")

	values := getInput("two")

	x := 0
	y := 0
	z := 0

	for _, s := range values {
		navigation := strings.Split(s, " ")
		distance, _ := strconv.Atoi(navigation[1])
		switch navigation[0] {
		case "forward":
			x += distance
			y += (z * distance)
		case "up":
			z -= distance
		case "down":
			z += distance
		}
	}

	total := x * y
	answer("Total Distance Traveled", total)
}

func DayThree() {
	title("Day 3: Binary Diagnostic")

	values := getInput("three")

	// length of rows
	length := len(values[0])
	// total rows
	rows := 0
	// final binary arrays
	gamma_rate := make([]int, length)
	epsilon_rate := make([]int, length)
	// sum of all ones in each column
	one_count := make([]int, length)

	// iterate through each row and count the ones in each column
	for _, s := range values {
		rows += 1
		report := strings.Split(s, "")

		for i := 0; i < length; i++ {
			if report[i] == "1" {
				one_count[i] += 1
			}
		}
	}

	for i := 0; i < length; i++ {
		// if more ones than zeroes...
		if one_count[i] > ((rows - 1) / 2) {
			gamma_rate[i] = 1
			epsilon_rate[i] = 0
		} else {
			gamma_rate[i] = 0
			epsilon_rate[i] = 1
		}
	}

	gamma, _ := strconv.ParseInt(strings.Trim(strings.Replace(fmt.Sprint(gamma_rate), " ", "", -1), "[]"), 2, 64)

	epsilon, _ := strconv.ParseInt(strings.Trim(strings.Replace(fmt.Sprint(epsilon_rate), " ", "", -1), "[]"), 2, 64)

	answer_64("Power consumption", (gamma * epsilon))
}

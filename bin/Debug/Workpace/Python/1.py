import random as r

def main():
	while r.randint(0, 2^32-1) < 1919810:
		print(r.randint(1,114514))

if __name__ == "__main__":
	main();
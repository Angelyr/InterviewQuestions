#https://leetcode.com/problems/jewels-and-stones/
def numJewelsInStones(J, S):
    result = 0
    for letterJ in J:
        for letterS in S:
            if letterJ == letterS: result+=1
                
    return result

#https://leetcode.com/problems/max-increase-to-keep-city-skyline/
def maxIncreaseKeepingSkyline(grid):
    front = []
    side = [] 
    i=0
    while i < len(grid):
        front.append(0)
        side.append(0)
        i+=1   
    i=0
    while i < len(grid):
        j=0
        while j < len(grid[i]):
            front[j] = max(front[j], grid[i][j])
            side[i] = max(side[i], grid[i][j])
            j+=1
        i+=1   
    sum = 0
    i=0
    while i < len(grid):
        j=0
        while j < len(grid[i]):
            sum += abs(grid[i][j] - min(front[j], side[i]))
            grid[i][j] = min(front[j], side[i])
            j+=1
        i+=1
    return sum
        
#https://leetcode.com/problems/reverse-string/
def reverseString(s):
    output = s[::-1]
    return output

#https://leetcode.com/problems/maximum-depth-of-binary-tree/
def maxDepth(root):
    if root == None: return 0
    return 1 + max(maxDepth(root.left), maxDepth(root.right) )

#https://leetcode.com/problems/single-number/
def singleNumber(nums):
    sumXOR = 0
    for num in nums:
        sumXOR ^= num
    return sumXOR

#https://leetcode.com/problems/fizz-buzz/
def fizzBuzz(n):
    i = 1
    output=[]
    while i <= n:
        if i%3 == 0 and i%5 == 0:
            output += ["FizzBuzz"]
        elif i%3 == 0:
            output += ["Fizz"]
        elif i%5 == 0:
            output += ["Buzz"]
        else:
            output += [str(i)]
        i+=1
    return output

#https://leetcode.com/problems/binary-tree-inorder-traversal/
def inorderTraversal(root):
    stack = []
    curr =  root
    output = []
    while curr != None or len(stack) > 0:
        while curr != None:
            stack.append(curr)
            curr = curr.left
        curr = stack.pop()
        output.append(curr.val)
        curr = curr.right
    return output

#https://leetcode.com/problems/two-sum/
def twoSum(nums, target):
    if len(nums) <= 1:
        return False
    buff_dict = {}
    for i in range(len(nums)):
        if nums[i] in buff_dict:
            return [buff_dict[nums[i]], i]
        else:
            buff_dict[target - nums[i]] = i
